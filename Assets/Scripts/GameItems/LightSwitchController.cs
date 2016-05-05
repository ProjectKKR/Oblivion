using UnityEngine;
using System.Collections;

public class LightSwitchController : GameItems {
	public LightController LC;
	public GameObject switchAxis;

	private const float angle = 10;
	private bool state;

	void Start () {
		state = true;
		interactable = true;
	}
	protected override void Interaction () {
		state = !state;
		switchAxis.transform.eulerAngles = new Vector3(0, state? 0 : angle, 0);
		LC.Light (state);
	}
}