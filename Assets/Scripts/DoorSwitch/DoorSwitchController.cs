using UnityEngine;
using System.Collections;

public class DoorSwitchController : GameItems {
	public GameObject switchAxis;
	private const float angle = 25;
	private bool state;

	void Start () {
		state = false;
	}


	protected override bool EquippedItemCheck (GameItems equipped) {
		return true;
	}

	protected override void Interaction () {
		state = !state;
		switchAxis.transform.eulerAngles = new Vector3(0, 0, state? -angle : 0);
	}

	protected override void PostProcess () {
		;
	}
}