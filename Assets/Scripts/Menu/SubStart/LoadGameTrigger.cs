using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class LoadGameTrigger : MonoBehaviour {

	public void Trigger(){
		// TODO : if saved data exists, load it, if not start a new game
		SceneManager.LoadScene("SNUPS");
	}
}
