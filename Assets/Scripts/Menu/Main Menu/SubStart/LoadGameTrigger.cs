using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class LoadGameTrigger : MonoBehaviour {

	public void Trigger(){
		// TODO : if saved data exists, load it, if not start a new game
		if (PlayerPrefs.HasKey ("Level_Name")) {
			SceneManager.LoadScene (PlayerPrefs.GetString ("Level_Name"));
		} else {
			SceneManager.LoadScene("SNUPS");
		}
	}
}
