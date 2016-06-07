using UnityEngine;
using System.Collections;

public class MainDoor :  GameItems {

	public GameObject endingMenu;

	protected override void Interaction () {
		endingMenu.SetActive (true);
	}
}