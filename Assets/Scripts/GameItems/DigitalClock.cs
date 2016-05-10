using UnityEngine;
using System.Collections;

public class DigitalClock : GameItems {
	public GameObject axis;
	public GameItems umbrella;
	private const float angle = 50;
	private bool state;

	void Start () {
		state = false;
	}

	protected override bool EquippedItemCheck (GameItems equipped){
		// TODO : if equipped == umbrella
		return equipped.Equals(umbrella);
	}

	protected override void Interaction() {
		state = !state;
		axis.transform.eulerAngles = new Vector3 (state? -angle : 0, 0, 0);
	}
}
