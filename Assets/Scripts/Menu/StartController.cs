using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class StartController : MonoBehaviour {
	public GameObject SubStart;
	// Use this for initialization
	void Start () {
		SubStart.SetActive (false);
	}
	public void LoadOblivion(){
		SubStart.SetActive (true);
		//SceneManager.LoadScene ("Oblivion");
	}
}
