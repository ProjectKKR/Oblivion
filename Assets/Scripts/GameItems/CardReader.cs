using UnityEngine;
using System.Collections;

public class CardReader : GameItems {
	public GameObject redLight;
	public GameObject greenLight;
	public Material redLightOff;
	public Material greenLightOn;
	public GameItems mainDoor;

	public GameItems card;

	protected override bool EquippedItemCheck (GameItems equipped){
		if (equipped == null) return false;
		return equipped.Equals (card);
	}

	protected override void Interaction () {
		redLight.GetComponent<Renderer> ().sharedMaterial = redLightOff;
		greenLight.GetComponent<Renderer> ().sharedMaterial = greenLightOn;
		mainDoor.ChainOperation (0);
		interactable = false;
	}
}
