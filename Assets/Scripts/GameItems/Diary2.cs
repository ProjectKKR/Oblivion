using UnityEngine;
using System.Collections;

public class Diary2 : GameItems {

	// Use this for initialization
	void Start () {
		zoomLocation = transform.position + new Vector3 (0.0f, 0.3f, 0.0f);
		zoomRotation = Quaternion.Euler (new Vector3 (90, 290, 0));
	}


	protected override void Interaction () {

	}
}
