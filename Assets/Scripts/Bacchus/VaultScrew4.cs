using UnityEngine;
using System.Collections;

public class VaultScrew4 : VaultScrew {
	void Start() {
		if (PlayerPrefs.HasKey ("Vault_Screw4_Scale")) {
			gameObject.transform.localScale = PlayerPrefsX.GetVector3 ("Vault_Screw4_Scale");
		}
	}
}
