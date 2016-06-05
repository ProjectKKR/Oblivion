using UnityEngine;
using System.Collections;

public class CabinetDoor : GameItems {
	public GameObject axis;
	private float openFlag = 1.0f;
	protected AudioSource open;
	protected float openAngle;

	public float getOpenFlag() {
		return openFlag;
	}

	public void setOpenFlag(float f) {
		openFlag = f;
	}

	protected override void Interaction () {
		axis.transform.Rotate (new Vector3 (0, openAngle * openFlag, 0));
		openFlag = - openFlag;
		if (openFlag != 1.0f) {
			open.Play ();
		}
	}
}


