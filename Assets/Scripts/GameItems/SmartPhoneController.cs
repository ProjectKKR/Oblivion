using UnityEngine;
using System.Collections;

public class SmartPhoneController : GameItems{
	public GameItems chargerComposed;
	public GameObject chargerComposedReal;
	public SmartPhone smartPhone;
	public GameObject lowBattery;
	public InventoryItemController iic;

	private bool opened;

	public bool getOpened() {
		return opened;
	}

	void Start () {
		opened = false;
		zoomLocation = transform.position + new Vector3 (0.0f, 0.32f, 0.0f);
		zoomRotation = Quaternion.Euler (new Vector3 (90, 0, 0));
		if (PlayerPrefs.HasKey ("Phone_Opened")) {
			opened = PlayerPrefsX.GetBool ("Phone_Opened");
		}
	}

	protected override void Interaction () {
		if (lowBattery.activeSelf == true) return;
		lowBattery.SetActive (true);
		Invoke ("LowBatteryOff", 1.0f);
	}

	private void LowBatteryOff () {
		lowBattery.SetActive (false);
	}

	protected override bool EquippedItemCheck (GameItems equipped){
		if (opened)
			return false;
		if (equipped == null) return true;
		if (equipped.Equals (chargerComposed)) {
			iic.Delete (chargerComposed);
			chargerComposedReal.transform.localScale = new Vector3 (2.0f, 2.0f, 2.0f);
			opened = true;
			smartPhone.OpenApp (1);
		} else {
			return true;
		}
		return false;
	}
}
