using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class ToNextLevel : MonoBehaviour {

	public string nextLevelName;

	public void Nextlevel(){
		PlayerPrefs.DeleteAll ();
		PlayerPrefs.SetString ("Level_Name", nextLevelName);
		SceneManager.LoadScene(nextLevelName);
	}
}
	