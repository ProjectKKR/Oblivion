using UnityEngine;
using System.Collections;

public class VaultScrew : GameItems {

	public BacchusVaultDoor door;
	public GameItems driver;

	protected override void Interaction() {
		transform.localScale = new Vector3 (0.0f, 0.0f, 0.0f);
		door.setScrewCount (door.getScrewCount () - 1);
	}

	protected override bool EquippedItemCheck (GameItems equipped) {
		if (equipped == null)
			return false;
		return equipped.Equals(driver);
	}
}
