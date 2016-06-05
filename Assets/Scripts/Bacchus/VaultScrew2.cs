using UnityEngine;
using System.Collections;

public class VaultScrew2 : VaultScrew {
	void Start() {
		if (PlayerPrefs.HasKey ("Vault_Screw2_Scale")) {
			gameObject.transform.localScale = PlayerPrefsX.GetVector3 ("Vault_Screw2_Scale");
		}
	}
}
