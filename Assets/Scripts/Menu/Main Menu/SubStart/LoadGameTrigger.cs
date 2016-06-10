using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class LoadGameTrigger : MonoBehaviour {

	public void Trigger(){
		if (PlayerPrefs.HasKey ("Level_Name")) {
			SceneManager.LoadScene (PlayerPrefs.GetString ("Level_Name"));
		} else {
			SceneManager.LoadScene("BACCHUS");
		}
	}
}
