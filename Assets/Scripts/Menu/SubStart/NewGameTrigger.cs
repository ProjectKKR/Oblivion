using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class NewGameTrigger : MonoBehaviour {
	public void Trigger(){
		//TODO : Delete all save data
		SceneManager.LoadScene("snups");
	}
}
