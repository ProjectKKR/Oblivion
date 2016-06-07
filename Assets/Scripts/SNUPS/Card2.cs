using UnityEngine;
using System.Collections;

public class Card2 : Card {
	void Start() {
		if (PlayerPrefs.HasKey ("Card2_Scale")) {
			gameObject.transform.localScale = PlayerPrefsX.GetVector3 ("Card2_Scale");
		}
	}
}
