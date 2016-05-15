using UnityEngine;
using System.Collections;

public class FiniteMovePuzzleScreen : GameItems {

	// Use this for initialization
	void Start () {
		zoomLocation = transform.position + new Vector3 (0, 0.8f, 0);
		zoomRotation = Quaternion.Euler (new Vector3 (90, 0, 0));
	}
	protected override void Interaction () {
	}
}
