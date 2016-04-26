﻿using UnityEngine;
using System.Collections;

public class LightSwitchController : GameItems {

	public GameObject switchAxis;

	private float angleOn = (float)(-10);
	private float angleOff = (float)(+10);
	private int state = 0;

	void Start () {
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