using UnityEngine;
using System.Collections;

public class DigitalClock : GameItems {
	public GameObject axis;
	private const float angle = 50;
	private bool state;

	void Start () {
		state = false;
	}

	new protected bool EquippedItemCheck (GameItems equipped){
		// TODO : if equipped == umbrella
		return true;
	}

	protected override void Interaction() {
		state = !state;
		axis.transform.eulerAngles = new Vector3 (state? -angle : 0, 0, 0);
	}
}
