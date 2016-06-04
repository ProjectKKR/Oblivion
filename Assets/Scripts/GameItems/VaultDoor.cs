using UnityEngine;
using System.Collections;

public class VaultDoor :  GameItems {
	public GameObject axis;
	private float openFlag = 1.0f;
	protected AudioSource open;

	public float getOpenFlag() {
		return openFlag;
	}

	public void setOpenFlag(float f) {
		openFlag = f;
	}

	protected override void Interaction () {
		axis.transform.Rotate (new Vector3 (0, -80.0f * openFlag, 0));
		openFlag = - openFlag;
		if (openFlag != 1.0f) {
			open.Play ();
		}
	}
}