using UnityEngine;
using System.Collections;

public class SaveTrigger : MonoBehaviour {

	public PlayerController player;
	public Camera mainCamera;
	public Computer computer;
	public VaultDoor vd1;
	public VaultDoor vd2;
	public GameObject card1;
	public GameObject card2;

	public void Trigger(){
		// Player Position & Rotation
		PlayerPrefsX.SetVector3 ("Player_Position", player.transform.position);
		PlayerPrefsX.SetQuaternion ("Player_Rotation", player.transform.rotation);

		// Camera Position & Rotation for Zoom
		PlayerPrefsX.SetBool ("Player_Zoom_Flag", player.getZoomFlag());
		PlayerPrefsX.SetVector3 ("Camera_Original_Position", player.getOriginalPos());
		PlayerPrefsX.SetQuaternion ("Camera_Original_Rotation", player.getOriginalRot());
		PlayerPrefsX.SetVector3 ("Camera_Position", mainCamera.transform.position);
		PlayerPrefsX.SetQuaternion ("Camera_Rotation", mainCamera.transform.rotation);

		// Computer Right Screen
		PlayerPrefsX.SetIntArray ("Computer_Text", computer.getInputCode());
		PlayerPrefs.SetInt ("Computer_Text_Length", computer.getLen ());
		PlayerPrefsX.SetBoolArray ("Computer_Clear_Flag", computer.getClearFlag ());

		// Computer Left Screen

		// Finite Move Puzzle

		// Vault Interaction
		PlayerPrefsX.SetBool ("Valut1_Door_Interactable", vd1.interactable);
		PlayerPrefsX.SetBool ("Valut2_Door_Interactable", vd2.interactable);
		PlayerPrefs.SetFloat ("Valut1_Door_Open_Flag", vd1.getOpenFlag ());
		PlayerPrefs.SetFloat ("Valut2_Door_Open_Flag", vd2.getOpenFlag ());

		// Card
		PlayerPrefsX.SetBool ("Card1_Active", card1.activeSelf);
		PlayerPrefsX.SetBool ("Card2_Active", card2.activeSelf);

		// Card Reader

		// Inventory

	}
}
