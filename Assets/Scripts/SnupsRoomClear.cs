using UnityEngine;
using UnityEditor.SceneManagement;
using System.Collections;

public class SnupsRoomClear : MonoBehaviour {

	public void SnupsClear(){
		//TODO clear save information
		EditorSceneManager.LoadScene("MainMenu");
	}
}
