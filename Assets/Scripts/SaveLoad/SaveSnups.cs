using UnityEngine;
using System.Collections;

public class SaveSnups : MonoBehaviour {

	public PlayerController player;
	public Camera mainCamera;
	public Computer computer;
	public VaultDoor vd1;
	public VaultDoor vd2;
	public GameObject card1;
	public GameObject card2;
	public CardReader cardReader;
	public InventoryItemController iic;
	public FiniteMoveManager1 round1;
	public FiniteMoveManager2 round2;
	public FiniteMoveManager3 round3;
	public FiniteMoveManager4 round4;
	public FiniteMoveManager5 round5;
	public GameObject clear;
	public NumberJump left;
	public LightSwitchController lightSwitch;
	public GameObject clockFace;

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

		// Computer Right Screen
		PlayerPrefsX.SetIntArray ("Computer_Text", computer.getInputCode());
		PlayerPrefs.SetInt ("Computer_Text_Length", computer.getLen ());
		PlayerPrefsX.SetBoolArray ("Computer_Clear_Flag", computer.getClearFlag ());

		// Computer Left Screen
		PlayerPrefsX.SetBool ("Monitor_Left_Active", left.gameObject.activeSelf);

		// Finite Move Puzzle
		PlayerPrefsX.SetBool ("Finite_Move_Puzzle_Round1", round1.gameObject.activeSelf);
		PlayerPrefsX.SetBool ("Finite_Move_Puzzle_Round2", round2.gameObject.activeSelf);
		PlayerPrefsX.SetBool ("Finite_Move_Puzzle_Round3", round3.gameObject.activeSelf);
		PlayerPrefsX.SetBool ("Finite_Move_Puzzle_Round4", round4.gameObject.activeSelf);
		PlayerPrefsX.SetBool ("Finite_Move_Puzzle_Round5", round5.gameObject.activeSelf);
		PlayerPrefsX.SetBool ("Finite_Move_Puzzle_Clear", clear.gameObject.activeSelf);

		// Vault Interaction
		PlayerPrefsX.SetBool ("Valut1_Door_Interactable", vd1.interactable);
		PlayerPrefsX.SetBool ("Valut2_Door_Interactable", vd2.interactable);
		PlayerPrefs.SetFloat ("Valut1_Door_Open_Flag", vd1.getOpenFlag ());
		PlayerPrefs.SetFloat ("Valut2_Door_Open_Flag", vd2.getOpenFlag ());

		// Light Switch
		PlayerPrefsX.SetBool ("Light_Switch_Interactable", lightSwitch.interactable);
		PlayerPrefsX.SetBool ("Light_Switch_State", lightSwitch.getState ());
		PlayerPrefsX.SetBool ("Clock_Face_Active", clockFace.activeSelf);

		// Card
		PlayerPrefsX.SetVector3 ("Card1_Scale", card1.transform.localScale);
		PlayerPrefsX.SetVector3 ("Card2_Scale", card2.transform.localScale);

		// Card Reader
		PlayerPrefsX.SetBool ("Card_Reader_Card_Flag1", cardReader.cardFlag1);
		PlayerPrefsX.SetBool ("Card_Reader_Card_Flag2", cardReader.cardFlag2);

		// Inventory
		PlayerPrefsX.SetStringArray ("Inventory_Item_Tag_List", iic.getTagList ());
	}
}
