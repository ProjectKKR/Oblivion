using UnityEngine;
using System.Collections;

public class SwitchController : GameItems {
	public GameObject switchAxis;
	private float angleOn = (float)(-25);
	private float angleOff = (float)(+25);
	private int state = 0;

	void Start () {
		distanceThreshold = 2.0f;
		interactable = true;
	}

	protected override void Interaction () {
		Debug.Log ("CLICK!");
		state = 1 - state;
		if (state==1) switchAxis.transform.Rotate (new Vector3 (0, 0, angleOn));
		if (state==0) switchAxis.transform.Rotate (new Vector3 (0, 0, angleOff));
	}

	protected override void PostProcess () {
		;
	}
}