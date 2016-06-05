using UnityEngine;
using System.Collections;

public class ChargerBody : GameItems {
	void Start() {
		if (PlayerPrefs.HasKey ("Charger_Body_Scale")) {
			gameObject.transform.localScale = PlayerPrefsX.GetVector3 ("Charger_Body_Scale");
		}
	}

	protected override void Interaction () {
		
	}
}
