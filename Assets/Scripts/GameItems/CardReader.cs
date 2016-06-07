using UnityEngine;
using System.Collections;

public class CardReader : GameItems {
	public GameObject redLight1;
	public GameObject greenLight1;
	public GameObject redLight2;
	public GameObject greenLight2;
	public Material redLightOff;
	public Material greenLightOn;

	public GameItems card1;
	public GameItems card2;
	public GameItems mainDoor;

	public bool cardFlag1 = true;
	public bool cardFlag2 = true;

	void Start() {
		if (PlayerPrefs.HasKey ("Card_Reader_Card_Flag1")) {
			cardFlag1 = PlayerPrefsX.GetBool ("Card_Reader_Card_Flag1");
			if (!cardFlag1) {
				redLight1.GetComponent<Renderer> ().sharedMaterial = redLightOff;
				greenLight1.GetComponent<Renderer> ().sharedMaterial = greenLightOn;
			}
		}

		if (PlayerPrefs.HasKey ("Card_Reader_Card_Flag2")) {
			cardFlag2 = PlayerPrefsX.GetBool ("Card_Reader_Card_Flag2");
			if (!cardFlag2) {
				redLight2.GetComponent<Renderer> ().sharedMaterial = redLightOff;
				greenLight2.GetComponent<Renderer> ().sharedMaterial = greenLightOn;
			}
		}

		if (!cardFlag1 && !cardFlag2) {
			mainDoor.interactable = true;
		}
	}

	protected override bool EquippedItemCheck (GameItems equipped){
		if (equipped == null) return false;
		if (equipped.Equals (card1)) {
			ChainOperation (0);
			return true;
		} else if (equipped.Equals (card2)) {
			ChainOperation (1);
			return true;
		}
		return false;
	}

	public override void ChainOperation (int caseNum) {
		if (caseNum == 0 && cardFlag1) {
			redLight1.GetComponent<Renderer> ().sharedMaterial = redLightOff;
			greenLight1.GetComponent<Renderer> ().sharedMaterial = greenLightOn;
			cardFlag1 = false;
		} else if (caseNum == 1 && cardFlag2) {
			redLight2.GetComponent<Renderer> ().sharedMaterial = redLightOff;
			greenLight2.GetComponent<Renderer> ().sharedMaterial = greenLightOn;
			cardFlag2 = false;
		}
		if (!cardFlag1 && !cardFlag2) {
			mainDoor.interactable = true;
		}
	}

	protected override void Interaction () {
		
	}
}
