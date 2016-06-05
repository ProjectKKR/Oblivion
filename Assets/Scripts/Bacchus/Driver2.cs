using UnityEngine;
using System.Collections;

public class Driver2 : Driver {
	void Start() {
		if (PlayerPrefs.HasKey ("Driver2_Scale")) {
			gameObject.transform.localScale = PlayerPrefsX.GetVector3 ("Driver2_Scale");
		}
	}
}
