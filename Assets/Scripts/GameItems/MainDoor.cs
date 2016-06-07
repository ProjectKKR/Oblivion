using UnityEngine;
using System.Collections;

public class MainDoor :  GameItems {

	public GameObject endingMenu;

	void Start() {
		if (PlayerPrefs.HasKey ("Main_Door_Interactable")) {
			interactable = PlayerPrefsX.GetBool ("Main_Door_Interactable");
		}
	}

	protected override void Interaction () {
		endingMenu.SetActive (true);
	}
}