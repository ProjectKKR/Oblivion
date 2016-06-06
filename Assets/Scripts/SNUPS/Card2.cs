using UnityEngine;
using System.Collections;

public class Card2 : Card {
	void Start() {
		if (PlayerPrefs.HasKey ("Card2_Active")) {
			gameObject.SetActive (PlayerPrefsX.GetBool ("Card2_Active"));
		}
	}
}
