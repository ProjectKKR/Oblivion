using UnityEngine;
using System.Collections;

public class SmartPhoneZoom : GameItems{

	public GameObject screen;
	public GameObject charger;

	void Start () {
		zoomLocation = transform.position + new Vector3 (0.0f, 1.0f, 0.0f);
		zoomRotation = Quaternion.Euler (new Vector3 (90, 180, 0));
	}

	protected override bool EquippedItemCheck (GameItems equipped){
		if (equipped == null) return false;
		if (equipped.Equals (charger)) {
			ChainOperation (0);
			return true;
		}
		return false;
	}

	public override void ChainOperation (int caseNum) {
		screen.SetActive (true);
	}
	protected override void Interaction(){
	}

}
