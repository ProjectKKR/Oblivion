using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class BackToTheMainTrigger : MonoBehaviour {
	public void Trigger(){
		SceneManager.LoadScene ("MainMenu");
	}
}
