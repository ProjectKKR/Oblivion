using UnityEngine;
using System.Collections;

public class VaultDoor2 : VaultDoor {
	void Start() {
		if (PlayerPrefs.HasKey ("Valut2_Door_Interactable")) {
			interactable = PlayerPrefsX.GetBool ("Valut2_Door_Interactable");
		}
		if (PlayerPrefs.HasKey ("Valut2_Door_Open_Flag")) {
			float value = PlayerPrefs.GetFloat ("Valut2_Door_Open_Flag");
			setOpenFlag(value);
			if (value == -1.0f) {
				axis.transform.Rotate (new Vector3 (0, -80.0f, 0));
			}
		}
	}
}
