using UnityEngine;
using System.Collections;

public class Door : GameItems {
	public float speed;
	public GameObject axis;

	private Ray ray;
	private RaycastHit hit;
	private float openFlag;

	// Use this for initialization
	void Start () {
		// TODO
		interactable = true;
		openFlag = 1.0f;
	}
	
	// Update is called once per frame
	protected override void Interaction () {
		axis.transform.Rotate (new Vector3 (0, 70.0f * openFlag, 0));
		openFlag = - openFlag;
	}

	protected override void PostProcess () {
		;
	}
}