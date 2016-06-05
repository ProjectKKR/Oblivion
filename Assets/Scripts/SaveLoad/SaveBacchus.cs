using UnityEngine;
using System.Collections;

public class SaveBacchus : MonoBehaviour {

	public PlayerController player;
	public Camera mainCamera;
	public InventoryItemController iic;
	public GameObject driver1;
	public GameObject driver2;
	public GameObject chargerBody;
	public GameObject chargerWire;
	public CabinetDoor1 cabinetDoor1;
	public CabinetDoor2 cabinetDoor2;
	public GameObject vaultScrew1;
	public GameObject vaultScrew2;
	public GameObject vaultScrew3;
	public GameObject vaultScrew4;
	public BacchusVaultDoor vaultDoor;

	public void Save() {
		// Player Position & Rotation
		PlayerPrefsX.SetVector3 ("Player_Position", player.transform.position);
		PlayerPrefsX.SetQuaternion ("Player_Rotation", player.transform.rotation);

		// Camera Position & Rotation for Zoom
		PlayerPrefsX.SetBool ("Player_Zoom_Flag", player.getZoomFlag());
		PlayerPrefsX.SetVector3 ("Camera_Original_Position", player.getOriginalPos());
		PlayerPrefsX.SetQuaternion ("Camera_Original_Rotation", player.getOriginalRot());
		PlayerPrefsX.SetVector3 ("Camera_Position", mainCamera.transform.position);
		PlayerPrefsX.SetQuaternion ("Camera_Rotation", mainCamera.transform.rotation);

		// Inventory
		PlayerPrefsX.SetStringArray ("Inventory_Item_Tag_List", iic.getTagList ());

		// GameItems
		PlayerPrefsX.SetVector3 ("Driver1_Scale", driver1.transform.localScale);
		PlayerPrefsX.SetVector3 ("Driver2_Scale", driver2.transform.localScale);
		PlayerPrefsX.SetVector3 ("Charger_Body_Scale", chargerBody.transform.localScale);
		PlayerPrefsX.SetVector3 ("Charger_Wire_Scale", chargerWire.transform.localScale);
		PlayerPrefs.SetFloat ("Cabinet_Door1_Open_Flag", cabinetDoor1.getOpenFlag ());
		PlayerPrefs.SetFloat ("Cabinet_Door2_Open_Flag", cabinetDoor2.getOpenFlag ());
		PlayerPrefsX.SetVector3 ("Vault_Screw1_Scale", vaultScrew1.transform.localScale);
		PlayerPrefsX.SetVector3 ("Vault_Screw2_Scale", vaultScrew2.transform.localScale);
		PlayerPrefsX.SetVector3 ("Vault_Screw3_Scale", vaultScrew3.transform.localScale);
		PlayerPrefsX.SetVector3 ("Vault_Screw4_Scale", vaultScrew4.transform.localScale);
		PlayerPrefs.SetInt ("Vault_Door_Count", vaultDoor.getScrewCount ());
		PlayerPrefsX.SetVector3 ("Vault_Door_Scale", vaultDoor.transform.localScale);
	}
}
