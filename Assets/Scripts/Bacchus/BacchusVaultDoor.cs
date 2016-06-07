using UnityEngine;
using System.Collections;

public class BacchusVaultDoor : GameItems {

	private int screwCount = 4;

	public int getScrewCount() {
		return screwCount;
	}

	public void setScrewCount(int num) {
		screwCount = num;
	}

	void Start() {
		zoomLocation = transform.position + new Vector3 (0.7f, 0.0f, 0.0f);
		zoomRotation = Quaternion.Euler (new Vector3 (0, -90, 0));

		if (PlayerPrefs.HasKey ("Vault_Door_Count")) {
			screwCount = PlayerPrefs.GetInt ("Vault_Door_Count");
		}

		if (PlayerPrefs.HasKey ("Vault_Door_Scale")) {
			transform.localScale = PlayerPrefsX.GetVector3 ("Vault_Door_Scale");
		}
	}

	protected override void Interaction() {
		if (screwCount == 0) {
			transform.localScale = new Vector3 (0.0f, 0.0f, 0.0f);
		}
	}
}
