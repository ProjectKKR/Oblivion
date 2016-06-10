using UnityEngine;
using System.Collections;

public class SequencePuzzle : GameItems {
	
	void Start () {
		zoomLocation = transform.position + new Vector3 (0, 0, 0.5f);
		zoomRotation = Quaternion.Euler (new Vector3 (0, 180, 0));
	}

	protected override void Interaction () {
		
	}
}
