using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;
using System.Collections;
using System.Collections.Generic;

public class PlayerController : MonoBehaviour {
	public Camera mainCamera;
	public GameObject PauseMenu;
	public GameObject UserInterface;
	public GameObject WhiteFrame;
	public VirtualJoystick_left jsL;
	public float moveSpeed;
	public float terminalRotationSpeed = 25.0f;
	public static InventoryItemController inventory;
	public InventoryItemController inventoryTemp;
	//-----------------------------------------------//
	private Ray ray;
	private RaycastHit hit;
	private Vector3 MoveVector;
	private Vector3 originalPos;
	private Quaternion originalRot;
	private Rigidbody rb;
	private float pcUpDownAngle;
	private bool zoomFlag;

	private int controlOption;
	private bool UITouched = false;
	private bool interactionEnable = true;
	private bool cameraDragging = false;
	private Vector3 prevMousePos;

	// Sensor Input Stabilizer
	private const int BUFFER_SIZE = 7;
	private float[] accelerometerBuffer = new float[BUFFER_SIZE];
	private float[] compassBuffer = new float[BUFFER_SIZE];
	private float accelSum = 0.0f, compassSum = 0.0f;
	private int accelIdx = 0, compassIdx = 0;
	//

	public bool getZoomFlag() {
		return zoomFlag;
	}

	public Vector3 getOriginalPos() {
		return originalPos;
	}

	public Quaternion getOriginalRot() {
		return originalRot;
	}

	void Start () {
		zoomFlag = false;
		WhiteFrame.SetActive (false);
		rb = gameObject.GetComponent<Rigidbody> ();
		rb.maxAngularVelocity = terminalRotationSpeed;
		inventory = inventoryTemp;

		for (int i = 0; i < BUFFER_SIZE; i++) {
			accelerometerBuffer [i] = 0.0f;
			compassBuffer [i] = 0.0f;
		}
		pcUpDownAngle = 0.0f;

		// ONLY ENABLE (OPTION 1)
		Input.compass.enabled = true;
		//while (Mathf.Abs (Input.compass.magneticHeading) < 1e-3)
		if (PlayerPrefs.HasKey ("Player_Position")) {
			transform.position = PlayerPrefsX.GetVector3 ("Player_Position");
		}

		if (PlayerPrefs.HasKey ("Player_Rotation")) {
			transform.rotation = PlayerPrefsX.GetQuaternion ("Player_Rotation");
		}

		if (PlayerPrefs.HasKey ("Player_Zoom_Flag")) {
			zoomFlag = PlayerPrefsX.GetBool ("Player_Zoom_Flag");
		}

		if (PlayerPrefs.HasKey ("Camera_Original_Position")) {
			originalPos = PlayerPrefsX.GetVector3 ("Camera_Original_Position");
		}

		if (PlayerPrefs.HasKey ("Camera_Original_Rotation")) {
			originalRot = PlayerPrefsX.GetQuaternion ("Camera_Original_Rotation");
		}

		if (zoomFlag) {
			TurnOffUI ();
			if (PlayerPrefs.HasKey ("Camera_Position"))
				mainCamera.transform.position = PlayerPrefsX.GetVector3 ("Camera_Position");
			if (PlayerPrefs.HasKey ("Camera_Rotation"))
				mainCamera.transform.rotation = PlayerPrefsX.GetQuaternion ("Camera_Rotation");
			rb.velocity = Vector3.zero;
		}

		// Option data should be loaded here
		// '0' for drag, '1' for acc, mag sensor input
		controlOption = 0;
	}

	void Update () {
		if (PauseMenu.activeInHierarchy) {
			rb.velocity = Vector3.zero;
		}

		else {
			if (!zoomFlag) {
				/* MOVE AROUND */
				MoveVector = LeftJoystickInput ();
				Vector3 v = MoveVector * moveSpeed;
				rb.AddRelativeForce (v * 20);
				float norm = rb.velocity.magnitude;
				if (rb.velocity.magnitude > 0.8f * norm)
					rb.velocity = rb.velocity.normalized * 0.8f * norm;
				if (MoveVector == Vector3.zero)
					rb.velocity = Vector3.zero;


				/* TURN HORIZONTAL & VERTICAL*/
				/* Control OPTION 0 */
				if (controlOption == 0) {
					if (Input.GetMouseButtonDown (0)) {
						interactionEnable = false;
						UITouched = IsPointerOverUIObject ();
						prevMousePos = Input.mousePosition;
					} else if (Input.GetMouseButton (0)) {
						if (cameraDragging) {
							// Horizontal Rotation
							float dragHorizontalRotation = (Input.mousePosition.x - prevMousePos.x) / 10.0f;
							transform.Rotate (0, dragHorizontalRotation, 0);

							// Vertical Rotation
							Quaternion Identity = mainCamera.transform.rotation;
							Vector3 euler = Identity.eulerAngles;
							if (euler.x > 180)
								euler.x -= 360;
							float dragVerticalRotation = (prevMousePos.y - Input.mousePosition.y) / 5.0f;
							euler.x += dragVerticalRotation;
							if (euler.x < -80)
								euler.x = -80;
							if (euler.x > 80)
								euler.x = 80;
							mainCamera.transform.rotation = Quaternion.Euler (euler);

							prevMousePos = Input.mousePosition;
						} else if ((Input.mousePosition - prevMousePos).magnitude > 20) {
							prevMousePos = Input.mousePosition;
							cameraDragging = true;
						}
					}
					if (Input.GetMouseButtonUp(0)) {
						if (cameraDragging) {
							cameraDragging = false;
						} else {
							interactionEnable = true;
						}
					}
				} // End Control OPTION 0


				/* Control OPTION 1 */
				/* Accelerometer & Compass Sensor */
				else {
					/* Horizontal Rotation */
					float compassAngle = Input.compass.magneticHeading;
					compassSum = 0.0f;
					float coefficient = 1.0f;
					compassBuffer [compassIdx] = compassAngle;
					for (int temp = 0, i = compassIdx; temp < BUFFER_SIZE; temp++,i = (i + 1) % BUFFER_SIZE) {
						float t = compassBuffer [i];
						if (Mathf.Abs (t - compassAngle) > 180.0f) {
							float t1 = t - 360.0f;
							float t2 = t + 360.0f;
							if (Mathf.Abs (t1 - compassAngle) > Mathf.Abs (t2 - compassAngle))
								t = t2;
							else
								t = t1;
						}
						coefficient /= 2.0f;
						compassSum += t * coefficient;
					}
					compassSum += compassAngle * coefficient;
					compassIdx = (compassIdx + 1) % BUFFER_SIZE;

					transform.rotation = Quaternion.Euler (0, compassSum, 0);


					/* Vertical Rotation */
					if (Input.GetKey (KeyCode.J)) {
						pcUpDownAngle -= 1.0f;
					} else if (Input.GetKey (KeyCode.K)) {
						pcUpDownAngle += 1.0f;
					}

					Vector3 Accel = Input.acceleration;
					float angle = 0;
					if (Accel != Vector3.zero)
						angle = Mathf.Atan2 (Accel.z, -Accel.y) * Mathf.Rad2Deg;
					accelSum += angle - accelerometerBuffer [accelIdx];
					accelerometerBuffer [accelIdx] = angle;
					accelIdx = (accelIdx + 1) % BUFFER_SIZE;

					Quaternion Identity = transform.rotation;
					Quaternion Rot = Identity;
					Vector3 euler = Rot.eulerAngles;
					euler.x = -accelSum / (float)BUFFER_SIZE - pcUpDownAngle;
					if (euler.x < -80)
						euler.x = -80;
					if (euler.x > 80)
						euler.x = 80;
					mainCamera.transform.rotation = Quaternion.Euler (euler);
				} // End Control OPTION 1

			} else {
				rb.velocity = Vector3.zero;
			}

			if (interactionEnable && !cameraDragging && Input.GetMouseButtonUp (0)) {
				ray = Camera.main.ScreenPointToRay (Input.mousePosition);
				if (Physics.Raycast (ray, out hit, Mathf.Infinity)) {
					if (!UITouched) {
						GameObject clickObj = hit.transform.gameObject;
						GameItems obj = clickObj.GetComponent<GameItems> ();
						if (obj != null) {
							Vector3 objloc = clickObj.transform.position;
							Vector3 myloc = transform.position;
							// Projection to X-Z, Ignore Y value
							objloc.y = myloc.y = 0;
							float distance = (myloc - objloc).magnitude;
							if (distance <= obj.DistanceThreshold) {
								if (!(obj.zoomable ^ zoomFlag)) {
									obj.ClickInteraction (inventory.CurrentItem());
									if (obj.collectable) {
										inventory.Add (obj);
										//Destroy (clickObj);
										//clickObj.SetActive (false);
										clickObj.transform.localScale = new Vector3 (0.0f, 0.0f, 0.0f);
									}
								}

								/* Zoom IN*/
								if (obj.zoomable) {
									ZoomIn (obj);
								}
							}
						}
					}
				}
			}
		}
	}

	private Vector3 LeftJoystickInput(){
		Vector3 dir = new Vector3();
		dir.x = jsL.Horizontal ();
		dir.z = jsL.Vertical ();
		if (dir.magnitude > 1)
			dir.Normalize ();
		return dir;
	}

	private bool IsPointerOverUIObject() {
		PointerEventData eventDataCurrentPosition = new PointerEventData(EventSystem.current);
		eventDataCurrentPosition.position = new Vector2(Input.mousePosition.x, Input.mousePosition.y);
		List<RaycastResult> results = new List<RaycastResult>();
		EventSystem.current.RaycastAll(eventDataCurrentPosition, results);
		return results.Count > 0;
	}

	public void ZoomIn(GameItems obj){
		Vector3 zoomPos = obj.ZoomLocation;
		Quaternion zoomRot = obj.ZoomRotation;
		if (!zoomFlag) {
			originalPos = mainCamera.transform.position; // save original position
			originalRot = mainCamera.transform.rotation;
		} else
			return;
		zoomFlag = true;
		TurnOffUI ();
		mainCamera.transform.Translate (zoomPos - originalPos,Space.World);
		mainCamera.transform.rotation = zoomRot;
		rb.velocity = Vector3.zero;
	}

	public void ZoomOut(){
		zoomFlag = false;
		mainCamera.transform.Translate (originalPos - mainCamera.transform.position, Space.World);
		mainCamera.transform.rotation = originalRot;
		TurnOnUI ();
	}

	private void TurnOffUI(){
		WhiteFrame.SetActive (true);
		UserInterface.SetActive (false);
	}

	private void TurnOnUI(){
		WhiteFrame.SetActive (false);
		UserInterface.SetActive (true);
	}
}
