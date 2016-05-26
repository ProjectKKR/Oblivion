using UnityEngine;
using System.Collections;

public class MonitorLeft : GameItems{

	public NumberJump left;

	void Start () {
		zoomLocation = transform.position + new Vector3 (-0.5f, 0.05f, -0.09f);
		zoomRotation = Quaternion.Euler (new Vector3 (0, 80, 0));

		if (PlayerPrefs.HasKey ("Monitor_Left_Active")) {
			left.gameObject.SetActive (PlayerPrefsX.GetBool ("Monitor_Left_Active"));
		}
	}

	protected override void Interaction () {

	}

}
