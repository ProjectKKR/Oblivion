using UnityEngine;
using System.Collections;

public class Diary : GameItems {
	public Vector3 position, rotation;
	// Use this for initialization
	void Start () {
		zoomLocation = transform.position + position;
		zoomRotation = Quaternion.Euler (rotation);
	}
	

	protected override void Interaction () {

	}
}
