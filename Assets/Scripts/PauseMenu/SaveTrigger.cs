using UnityEngine;
using System.Collections;

public class SaveTrigger : MonoBehaviour {

	public PlayerController player;
	public Camera mainCamera;
	public Computer computer;

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

	}
}
