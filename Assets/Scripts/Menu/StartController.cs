using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Collections;

public class StartController : MonoBehaviour {
	public GameObject SubStart;
	public Text loadingMessage;
	int state;

	// Use this for initialization
	void Start () {
		SubStart.SetActive (false);
		state = 0;
	}
	public void LoadSubStart(){
		SubStart.SetActive (true);
		//InvokeRepeating ("textUpdate", 0.0f, 0.2f);
		SceneManager.LoadScene ("Oblivion");
	}
	/*
	public void textUpdate () {
		loadingMessage.text = "Now Loading";
		for (int i = 0; i < 4; i++) {
			if (i < state)
				loadingMessage.text = loadingMessage.text + ".";
			else
				loadingMessage.text = loadingMessage.text + " ";
		}
		print (loadingMessage.text);
		state = (state + 1) % 4;
	}
	*/
}
