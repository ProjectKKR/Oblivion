using UnityEngine;
using System.Collections;

public class Card1 : Card {
	void Start() {
		if (PlayerPrefs.HasKey ("Card1_Active")) {
			gameObject.SetActive (PlayerPrefsX.GetBool ("Card1_Active"));
		}
	}
}
