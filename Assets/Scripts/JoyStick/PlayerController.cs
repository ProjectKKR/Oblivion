using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class PlayerController : MonoBehaviour {
	public VirtualJoystick_left jsL;
	public VirtualJoystick_right jsR;
	public float moveSpeed;
	public float terminalRotationSpeed = 25.0f;
	public Camera mainCamera;
	private Ray ray;
	private RaycastHit hit;

	private Vector3 MoveVector;
	private Rigidbody rb;

	private float[] array = new float[10];
	private float sum = 0.0f;
	private int idx = 0;

	private List<GameItems> inventory;

	void Start () {
		rb = gameObject.GetComponent<Rigidbody> ();
		rb.maxAngularVelocity = terminalRotationSpeed;

		for (int i = 0; i < 10; i++)
			array [i] = 0.0f;

		inventory = new List<GameItems> ();
	}

	void Update () {
		/* Rotate LEFT and RIGHT */
		/*-----------------------------------------------*/
		MoveVector = PoolRightInput ();
		Vector3 v = MoveVector * moveSpeed;
		rb.AddRelativeForce (v*20);
		float norm = rb.velocity.magnitude;
		if (rb.velocity.magnitude > 0.8f*norm)
			rb.velocity = rb.velocity.normalized * 0.8f * norm;
		if (MoveVector == Vector3.zero)
			rb.velocity = Vector3.zero;
		gameObject.transform.Rotate (new Vector3(0,jsR.Turn ()*1.3f,0),Space.World);
		/*-----------------------------------------------*/


		/* Rotate UP and Down*/
		/*-----------------------------------------------*/
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
		euler.x = -sum/10.0f;
		transform.rotation = Quaternion.Euler(euler);
		/*-----------------------------------------------*/

		if(Input.GetMouseButtonDown(0)){
			ray = Camera.main.ScreenPointToRay(Input.mousePosition);

			if(Physics.Raycast(ray, out hit, Mathf.Infinity)){
				GameObject clickObj = hit.transform.gameObject;
				GameItems obj = clickObj.GetComponent<GameItems>();
				if (obj != null) {
					Vector3 objloc = clickObj.transform.position;
					float distance = (transform.position - objloc).magnitude;
					if (distance <= obj.DistanceThreshold) {
						obj.ClickInteraction ();
						if (obj.collectable) {
							inventory.Add (obj);
							Destroy (clickObj);
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
}