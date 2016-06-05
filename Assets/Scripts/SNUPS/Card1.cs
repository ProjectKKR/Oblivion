using UnityEngine;
using System.Collections;

public class Card1 : Card {
	void Start() {
		if (PlayerPrefs.HasKey ("Card1_Scale")) {
			gameObject.transform.localScale = PlayerPrefsX.GetVector3 ("Card1_Scale");
		}
	}
}
