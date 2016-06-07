using UnityEngine;
using System.Collections;

public class ChargerComposed : GameItems {
	void Start() {
		if (PlayerPrefs.HasKey ("Charger_Composed_Scale")) {
			gameObject.transform.localScale = PlayerPrefsX.GetVector3 ("Charger_Composed_Scale");
		}
	}

	protected override void Interaction() {

	}
}
