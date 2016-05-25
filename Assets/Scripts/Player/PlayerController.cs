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
	public VirtualJoystick_right jsR;
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
	private float[] accelArray = new float[10];
	private float[] compassArray = new float[10];
	private float accelSum = 0.0f, compassSum = 0.0f;
	private int accelIdx = 0, compassIdx = 0;
	private bool zoomFlag;
	private const int NUM = 7;


	void Start () {
		zoomFlag = false;
		WhiteFrame.SetActive (false);
		rb = gameObject.GetComponent<Rigidbody> ();
		rb.maxAngularVelocity = terminalRotationSpeed;
		inventory = inventoryTemp;

		for (int i = 0; i < 10; i++) {
			accelArray [i] = 0.0f;
			compassArray [i] = 0.0f;
		}
		pcUpDownAngle = 0.0f;

		Input.compass.enabled = true;
		//while (Mathf.Abs (Input.compass.magneticHeading) < 1e-3)
		if (PlayerPrefs.HasKey ("playerPosition")) {
			transform.position = PlayerPrefsX.GetVector3 ("playerPosition");
			transform.rotation = PlayerPrefsX.GetQuaternion ("playerRotation");
		}
	}

	void Update () {
		if (PauseMenu.activeInHierarchy) {
			rb.velocity = Vector3.zero;
		}

		else {
			if (!zoomFlag) {
				/* Move Around & Rotate LEFT and RIGHT */
				/*-----------------------------------------------*/

				MoveVector = PoolRightInput ();
				Vector3 v = MoveVector * moveSpeed;
				rb.AddRelativeForce (v * 20);
				float norm = rb.velocity.magnitude;
				if (rb.velocity.magnitude > 0.8f * norm)
					rb.velocity = rb.velocity.normalized * 0.8f * norm;
				if (MoveVector == Vector3.zero)
					rb.velocity = Vector3.zero;
				gameObject.transform.Rotate (new Vector3 (0, jsR.Turn () * 2.3f, 0), Space.World);

				/*
				MoveVector = PoolRightInput ();
				Vector3 v = MoveVector * moveSpeed;
				rb.AddRelativeForce (v * 20);
				float norm = rb.velocity.magnitude;
				if (rb.velocity.magnitude > 0.8f * norm)
					rb.velocity = rb.velocity.normalized * 0.8f * norm;
				if (MoveVector == Vector3.zero)
					rb.velocity = Vector3.zero;
				//transform.Rotate (new Vector3 (0, jsR.Turn () * 2.3f, 0), Space.World);
				float compassAngle = Input.compass.magneticHeading;
				compassSum = 0.0f;
				float coefficient = 1.0f;
				compassArray [compassIdx] = compassAngle;
				for (int temp = 0, i = compassIdx; temp < NUM; temp++,i = (i + 1) % NUM) {
					float t = compassArray [i];
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
				compassIdx = (compassIdx + 1) % NUM;

				transform.rotation = Quaternion.Euler(0,compassSum,0);
				*/

				/* Rotate UP and Down*/
				/*-----------------------------------------------*/
				if (Input.GetKey (KeyCode.J)) {
					pcUpDownAngle -= 1.0f;
				} else if (Input.GetKey (KeyCode.K)) {
					pcUpDownAngle += 1.0f;
				}

				Vector3 Accel = Input.acceleration;
				float angle = 0;
				if (Accel != Vector3.zero)
					angle = Mathf.Atan2 (Accel.z, -Accel.y) * Mathf.Rad2Deg;
				accelSum += angle - accelArray [accelIdx];
				accelArray [accelIdx] = angle;
				accelIdx = (accelIdx + 1) % NUM;

				Quaternion Identity = transform.rotation;
				Quaternion Rot = Identity;
				Vector3 euler = Rot.eulerAngles;
				euler.x = -accelSum / (float)NUM - pcUpDownAngle;
				if (euler.x < -80)
					euler.x = -80;
				if (euler.x > 80)
					euler.x = 80;
				mainCamera.transform.rotation = Quaternion.Euler (euler);
				/*-----------------------------------------------*/
			} else {
				rb.velocity = Vector3.zero;
			}

			if (Input.GetMouseButtonDown (0)) {
				ray = Camera.main.ScreenPointToRay (Input.mousePosition);
				if (Physics.Raycast (ray, out hit, Mathf.Infinity)) {
					if (!IsPointerOverUIObject ()) {
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
										clickObj.SetActive(false);
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

	private Vector3 PoolRightInput(){
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