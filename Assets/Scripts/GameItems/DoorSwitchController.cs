using UnityEngine;
using System.Collections;

public class DoorSwitchController : GameItems {
	public GameObject switchAxis;
	public GameObject ClockFace;
	private const float angle = 25;
	private bool state;

	void Start () {
		state = false;
	}

	protected override void Interaction () {
		state = !state;
		switchAxis.transform.eulerAngles = new Vector3(0, 90, state? -angle : 0);
		ClockFace.SetActive (state);
	}
}