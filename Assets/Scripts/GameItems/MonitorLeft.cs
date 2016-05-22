using UnityEngine;
using System.Collections;

public class MonitorLeft : GameItems{

	void Start () {
		zoomLocation = transform.position + new Vector3 (-0.5f, 0.05f, -0.09f);
		zoomRotation = Quaternion.Euler (new Vector3 (0, 80, 0));
	}

	protected override void Interaction () {

	}

}
