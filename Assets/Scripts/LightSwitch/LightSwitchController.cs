using UnityEngine;
using System.Collections;

public class LightSwitchController : GameItems {
	public LightController LC;
	public GameObject switchAxis;

	private const float angle = 10;
	private bool state;

	void Start () {
		state = false;
		interactable = true;
	}


	protected override bool EquippedItemCheck (GameItems equipped) {
		return true;
	}

	protected override void Interaction () {
		state = !state;
		switchAxis.transform.eulerAngles = new Vector3(0, 0, state? 0 : -angle);
		LC.Light (state);
	}

	protected override void PostProcess () {
		;
	}
}