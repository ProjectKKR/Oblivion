using UnityEngine;
using System.Collections;

public class Diary : GameItems {

	// Use this for initialization
	void Start () {
		zoomLocation = transform.position + new Vector3 (0.0f, 0.3f, 0.0f);
		zoomRotation = Quaternion.Euler (new Vector3 (90, 41, 0));
	}
	

	protected override void Interaction () {

	}
}
