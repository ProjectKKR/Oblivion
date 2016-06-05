using UnityEngine;
using System.Collections;

public class VaultScrew1 : VaultScrew {
	void Start() {
		if (PlayerPrefs.HasKey ("Vault_Screw1_Scale")) {
			print (PlayerPrefsX.GetVector3 ("Vault_Screw1_Scale"));
			gameObject.transform.localScale = PlayerPrefsX.GetVector3 ("Vault_Screw1_Scale");
		}
	}
}
