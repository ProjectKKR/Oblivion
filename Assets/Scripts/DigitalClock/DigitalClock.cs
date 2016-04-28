using UnityEngine;
using System.Collections;

public class DigitalClock : GameItems {

	protected override bool EquippedItemCheck(GameItems equipped) {
		return true;
	}

	protected override void Interaction() {
		transform.eulerAngles = new Vector3 (-50, 0, 0);
	}

	protected override void PostProcess() {
		;
	}
}
