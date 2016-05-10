using UnityEngine;
using System.Collections;

public class MainDoor :  GameItems {

	public GameObject door;
	public float speed = -1.1f;
	private bool openFlag = false;

	protected override void Interaction () {
		if (openFlag)
			door.transform.Translate (new Vector3 (0, 0, 1) * speed);
		else
			door.transform.Translate (new Vector3 (0, 0, -1) * speed);
		openFlag = !openFlag;
	}

	public override void ChainOperation (int caseNum) {
		if (caseNum == 0) {
			Interaction ();
		}
	}
}