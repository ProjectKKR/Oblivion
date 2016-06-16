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
	public DragView dragView;
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
	public bool zooming;
	private Vector3 deltaPos;
	private Quaternion sourceRot, destRot;
	private int deltaCount;

	private int beforeTouchCount = 0;

	private int controlOption;
	private bool interactionEnable = true;
	private bool cameraDragging = false;
	private const int dragPixelThreshold = 30;
	private Vector2 prevMousePos;

	// Sensor Input Stabilizer
	private const int BUFFER_SIZE = 9;
	private float[] accelerometerBuffer = new float[BUFFER_SIZE];
	private float[] compassBuffer = new float[BUFFER_SIZE];
	private float accelSum = 0.0f, compassSum = 0.0f;
	private int accelIdx = 0, compassIdx = 0;

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
		zooming = false;
		deltaCount = 0;
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
		controlOption = Static.GetControlOption();
	}

	void Update () {
		if (PauseMenu.activeInHierarchy) {
			rb.velocity = Vector3.zero;
		} else if (zooming) {
			if (deltaCount>0) {
				deltaCount--;
				mainCamera.transform.Translate (deltaPos, Space.World);
				mainCamera.transform.rotation = Quaternion.Slerp (sourceRot, destRot, 1.0f - (float)deltaCount / 10.0f);
			} else {
				zooming = false;
			}
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
				/* Control OPTION 3 */
				/* Screen Drag Input */
				if (controlOption == 3) {
					if (Input.touchCount != beforeTouchCount) {
						cameraDragging = false;
					}
					beforeTouchCount = Input.touchCount;

					Vector2 currPos = dragView.GetInputVector ();
					bool dragTouched = dragView.isTouched ();

					if (Input.GetMouseButtonDown (0)) {
						interactionEnable = false;
						prevMousePos = currPos;
					} else if (Input.GetMouseButton (0)) {
						if (cameraDragging) {
							if (dragTouched) {
								// Horizontal Rotation
								float dragHorizontalRotation = -(currPos.x - prevMousePos.x) / 10.0f;
								transform.Rotate (0, dragHorizontalRotation, 0);
								// Vertical Rotation
								Quaternion Identity = mainCamera.transform.rotation;
								Vector3 euler = Identity.eulerAngles;
								if (euler.x > 180)
									euler.x -= 360;
								float dragVerticalRotation = -(prevMousePos.y - currPos.y) / 8.0f;
								euler.x += dragVerticalRotation;
								if (euler.x < -80)
									euler.x = -80;
								if (euler.x > 80)
									euler.x = 80;
								mainCamera.transform.rotation = Quaternion.Euler (euler);

								prevMousePos = currPos;
							}
						} else if ((currPos - prevMousePos).magnitude > dragPixelThreshold) {
							if (dragTouched) {
								prevMousePos = currPos;
								cameraDragging = true;
							}
						}
					}
					if (Input.GetMouseButtonUp (0)) {
						if (cameraDragging) {
							cameraDragging = false;
						} else {
							interactionEnable = true;
						}
					}
				}

				/* Control OPTION 2 */
				/* Accelerometer & Horizontal Rotaion with Drag */
				else if (controlOption == 2) {
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

					if (Input.touchCount != beforeTouchCount) {
						cameraDragging = false;
					}
					beforeTouchCount = Input.touchCount;

					Vector2 currPos = dragView.GetInputVector ();
					bool dragTouched = dragView.isTouched ();

					if (Input.GetMouseButtonDown (0)) {
						interactionEnable = false;
						prevMousePos = currPos;
					} else if (Input.GetMouseButton (0)) {
						if (cameraDragging) {
							if (dragTouched) {
								// Horizontal Rotation
								float dragHorizontalRotation = -(currPos.x - prevMousePos.x) / 10.0f;
								transform.Rotate (0, dragHorizontalRotation, 0);
								prevMousePos = currPos;
							}
						} else if ((currPos - prevMousePos).magnitude > dragPixelThreshold) {
							if (dragTouched) {
								prevMousePos = currPos;
								cameraDragging = true;
							}
						}
					}
					if (Input.GetMouseButtonUp (0)) {
						if (cameraDragging) {
							cameraDragging = false;
						} else {
							interactionEnable = true;
						}
					}
				}

				/* Control OPTION 1 */
				/* Accelerometer & Compass Sensor */
				else if (controlOption == 1){
					/* Horizontal Rotation */
					float compassAngle = Input.compass.magneticHeading;
					compassSum = 0.0f;
					float coefficient = 1.0f / (float)BUFFER_SIZE;
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
						compassSum += t * coefficient;
					}
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
				}

			} else {
				rb.velocity = Vector3.zero;
			}

			if (interactionEnable && !cameraDragging && Input.GetMouseButtonUp (0)) {
				ray = Camera.main.ScreenPointToRay (Input.mousePosition);
				int camDragLayermask = 1 << 8;
				if (Physics.Raycast (ray, out hit, Mathf.Infinity, ~camDragLayermask)) {
					if (!IsPointerOverUIObject()) {
						GameObject clickObj = hit.transform.gameObject;
						GameItems obj = clickObj.GetComponent<GameItems> ();
						if (obj != null) {
							Vector3 objloc = clickObj.transform.position;
							Vector3 myloc = transform.position;
							// Projection to X-Z, Ignore Y value
							objloc.y = myloc.y = 0;
							float distance = (myloc - objloc).magnitude;
							if (distance <= obj.DistanceThreshold) {
								if (!(obj.zoomable ^ zoomFlag) || !obj.zoomable) {
									obj.ClickInteraction (inventory.CurrentItem());
								}

								if (obj.collectable) {
									inventory.Add (obj);
									clickObj.transform.localScale = new Vector3 (0.0f, 0.0f, 0.0f);
								}

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
		return results.Count > 1;
	}

	public void ZoomIn(GameItems obj){
		rb.velocity = Vector3.zero;
		Vector3 zoomPos = obj.ZoomLocation;
		Quaternion zoomRot = obj.ZoomRotation;
		if (!zoomFlag) {
			originalPos = mainCamera.transform.position;
			originalRot = mainCamera.transform.rotation;
		} else
			return;
		zoomFlag = true;
		TurnOffUI ();

		zooming = true;
		deltaCount = 10;
		deltaPos = (zoomPos - originalPos)/(float)deltaCount;
		sourceRot = originalRot;
		destRot = zoomRot;
		rb.velocity = Vector3.zero;
	}

	public void ZoomOut(){
		zoomFlag = false;
		zooming = true;
		deltaCount = 10;
		deltaPos = (originalPos - mainCamera.transform.position)/(float)deltaCount;
		sourceRot = mainCamera.transform.rotation;
		destRot = originalRot;
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
