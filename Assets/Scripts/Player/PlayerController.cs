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
	//-----------------------------------------------//
	private Ray ray;
	private RaycastHit hit;
	private Vector3 MoveVector;
	private Vector3 originalPos;
	private Quaternion originalRot;
	private Rigidbody rb;
	private float pcUpDownAngle;
	private float[] array = new float[10];
	private float sum = 0.0f;
	private int idx = 0;
	private bool zoomFlag;

	private GameItems equipped;

	private List<GameItems> inventory;


	void Start () {
		equipped = null;
		zoomFlag = false;
		WhiteFrame.SetActive (false);
		rb = gameObject.GetComponent<Rigidbody> ();
		rb.maxAngularVelocity = terminalRotationSpeed;

		for (int i = 0; i < 10; i++)
			array [i] = 0.0f;
		pcUpDownAngle = 0.0f;

		inventory = new List<GameItems> ();
	}

	void Update () {
		if (PauseMenu.activeInHierarchy) {
			rb.velocity = Vector3.zero;
		} else{
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
				/*-----------------------------------------------*/


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
				sum += angle - array [idx];
				array [idx] = angle;
				idx = (idx + 1) % 10;

				Quaternion Identity = transform.rotation;
				Quaternion Rot = Identity;
				Vector3 euler = Rot.eulerAngles;
				euler.x = -sum / 10.0f - pcUpDownAngle;
				if (euler.x < -80)
					euler.x = -80;
				if (euler.x > 80)
					euler.x = 80;
				transform.rotation = Quaternion.Euler (euler);
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
									obj.ClickInteraction (null);
									if (obj.collectable) {
										inventory.Add (obj);
										Destroy (clickObj);
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
		Vector3 zoomPos = obj.getLocation ();
		Vector3 Pos = transform.position;
		Quaternion zoomRot = obj.getRotation ();
		if (!zoomFlag) {
			originalPos = transform.position; // save original position
			originalRot = transform.rotation;
		}
		zoomFlag = true;
		TurnOffUI ();
		transform.Translate (zoomPos - Pos,Space.World);
		transform.rotation = zoomRot;
		rb.velocity = Vector3.zero;
	}

	public void ZoomOut(){
		zoomFlag = false;
		transform.Translate (originalPos - transform.position, Space.World);
		transform.rotation = originalRot;
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