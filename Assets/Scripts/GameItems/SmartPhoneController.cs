using UnityEngine;
using System.Collections;

public class SmartPhoneController : GameItems{
	public GameItems chargerComposed;
	public GameObject chargerComposedReal;
	public SmartPhone smartPhone;
	private bool opened;
	void Start () {
		opened = false;
		zoomLocation = transform.position + new Vector3 (0.0f, 0.23f, 0.0f);
		zoomRotation = Quaternion.Euler (new Vector3 (90, 0, 0));
	}

	protected override void Interaction () {
		// TODO : check equipping charger
	}

	protected override bool EquippedItemCheck (GameItems equipped){
		if (opened)
			return false;
		if (equipped == null) return false;
		if (equipped.Equals (chargerComposed)) {
			chargerComposedReal.SetActive (true);
			zoomable = true;
			smartPhone.OpenApp (1);
			opened = true;
		}
		return false;
	}
}
