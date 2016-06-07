using UnityEngine;
using System.Collections;

public class ChargerWire : GameItems {
	void Start() {
		if (PlayerPrefs.HasKey ("Charger_Wire_Scale")) {
			gameObject.transform.localScale = PlayerPrefsX.GetVector3 ("Charger_Wire_Scale");
		}
	}

	protected override void Interaction() {

	}
}
