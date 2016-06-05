using UnityEngine;
using System.Collections;

public class TrashBin : GameItems {

	void Start () {
		zoomLocation = transform.position + new Vector3 (-0.2f, 0.7f, 0.2f);
		zoomRotation = Quaternion.Euler (new Vector3 (90, -90, 0));
	}

	protected override void Interaction () {
		
	}
}
