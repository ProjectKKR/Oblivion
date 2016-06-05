using UnityEngine;
using System.Collections;

public class VaultScrew3 : VaultScrew {
	void Start() {
		if (PlayerPrefs.HasKey ("Vault_Screw3_Scale")) {
			gameObject.transform.localScale = PlayerPrefsX.GetVector3 ("Vault_Screw3_Scale");
		}
	}
}
