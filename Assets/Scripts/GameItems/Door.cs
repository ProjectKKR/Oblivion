using UnityEngine;
using System.Collections;

public class Door :  GameItems {
	public float speed;
	public GameObject axis;

	private Ray ray;
	private RaycastHit hit;
	private float openFlag=1.0f;

	protected override void Interaction () {
		axis.transform.Rotate (new Vector3 (0, -80.0f * openFlag, 0));
		openFlag = - openFlag;
	}
}