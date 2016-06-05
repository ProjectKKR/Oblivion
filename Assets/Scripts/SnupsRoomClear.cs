using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class SnupsRoomClear : MonoBehaviour {

	public void SnupsClear(){
		//TODO clear save information
		SceneManager.LoadScene("MainMenu");
	}
}
