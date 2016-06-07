using UnityEngine;
using System.Collections;

public class Driver1 : Driver {
	void Start() {
		if (PlayerPrefs.HasKey ("Driver1_Scale")) {
			gameObject.transform.localScale = PlayerPrefsX.GetVector3 ("Driver1_Scale");
		}
	}
}
