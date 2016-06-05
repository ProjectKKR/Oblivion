using UnityEngine;
using System.Collections;

public class CabinetDoor1 : CabinetDoor {
	void Start() {
		open = GetComponent<AudioSource> ();
		openAngle = 80.0f;
//		if (PlayerPrefs.HasKey ("Valut1_Door_Interactable")) {
//			interactable = PlayerPrefsX.GetBool ("Valut1_Door_Interactable");
//		}
//		if (PlayerPrefs.HasKey ("Valut1_Door_Open_Flag")) {
//			float value = PlayerPrefs.GetFloat ("Valut1_Door_Open_Flag");
//			setOpenFlag(value);
//			if (value == -1.0f) {
//				axis.transform.Rotate (new Vector3 (0, -80.0f, 0));
//			}
//		}
	}
}
