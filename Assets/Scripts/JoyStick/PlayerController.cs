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
	// Use this for initialization

	private List<GameItems> inventory;

	void Start () {
		rb = gameObject.GetComponent<Rigidbody> ();
		rb.maxAngularVelocity = terminalRotationSpeed;

		inventory = new List<GameItems> ();
	}
	
	// Update is called once per frame
	void Update () {
		MoveVector = PoolRightInput ();
		Vector3 v = MoveVector * moveSpeed;
		rb.AddRelativeForce (v*20);
		float norm = rb.velocity.magnitude;
		if (rb.velocity.magnitude > 0.8f*norm)
			rb.velocity = rb.velocity.normalized * 0.8f * norm;
		if (MoveVector == Vector3.zero)
			rb.velocity = Vector3.zero;
		gameObject.transform.Rotate (new Vector3(0,jsR.Turn ()*1.3f,0));

		if(Input.GetMouseButtonDown(0)){
			ray = Camera.main.ScreenPointToRay(Input.mousePosition);

			if(Physics.Raycast(ray, out hit, Mathf.Infinity)){
				GameObject clickObj = hit.transform.gameObject;
				GameItems obj = clickObj.GetComponent<GameItems>();
				if (obj != null) {
					Vector3 objloc = clickObj.transform.position;
					float distance = (transform.position - objloc).magnitude;
					if (distance <= obj.distanceThreshold) {
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
