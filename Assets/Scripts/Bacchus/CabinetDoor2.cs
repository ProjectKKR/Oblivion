﻿using UnityEngine;
using System.Collections;

public class CabinetDoor2 : CabinetDoor {
	void Start() {
		open = GetComponent<AudioSource> ();
		openAngle = -80.0f;

		if (PlayerPrefs.HasKey ("Cabinet_Door2_Open_Flag")) {
			float value = PlayerPrefs.GetFloat ("Cabinet_Door2_Open_Flag");
			setOpenFlag (value);
			if (value == -1.0f) {
				axis.transform.Rotate (new Vector3 (0, openAngle, 0));
			}
		}
	}
}
