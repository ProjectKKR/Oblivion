using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class StartController : MonoBehaviour {
	public GameObject SubStart;
	// Use this for initialization
	void Start () {
		SubStart.SetActive (false);
	}

	void Update(){
		if (Input.GetKey (KeyCode.Escape)) {
			SubStart.SetActive (false);
		}
	}
	public void LoadSubStart(){
		SubStart.SetActive (true);
		//SceneManager.LoadScene ("Oblivion");
	}
}
