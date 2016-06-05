using UnityEngine;
using System.Collections;

public class SmartPhoneZoom : GameItems{
	void Start () {
		zoomLocation = transform.position + new Vector3 (0.0f, 1.1f, 0.0f);
		zoomRotation = Quaternion.Euler (new Vector3 (90, 180, 0));
	}

	protected override void Interaction () {
		// TODO : check equipping charger
	}

}
