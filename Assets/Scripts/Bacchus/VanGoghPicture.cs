using UnityEngine;
using System.Collections;

public class VanGoghPicture : GameItems {
	public GameObject axis;
	private bool state = false;
	private float angle = -30.0f;

	protected override void Interaction() {
		state = !state;
		axis.transform.eulerAngles = new Vector3 (state ? angle : 0, 0, 0);
	}
}
