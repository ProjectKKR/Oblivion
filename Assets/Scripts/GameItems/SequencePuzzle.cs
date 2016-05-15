using UnityEngine;
using System.Collections;

public class SequencePuzzle : GameItems {
	
	void Start () {
		zoomLocation = transform.position + new Vector3 (0, 0.5f, 0);
		zoomRotation = Quaternion.Euler (new Vector3 (90, 0, 0));
	}

	protected override void Interaction () {
		
	}
}
