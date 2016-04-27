using UnityEngine;
using System.Collections;

public class LightSwitchController : GameItems {
	public LightController LC;
	public GameObject switchAxis;

	private float angleOn = (float)(-10);
	private float angleOff = (float)(+10);

	private bool state;

	void Start () {
		interactable = true;
	}


	protected override void EquippedItemCheck (GameItems equipped) {
		return true;
	}

	protected override void Interaction () {
		state = !state;
		LC.Light (state);
	}

	protected override void PostProcess () {
		;
	}
}