using UnityEngine;
using System.Collections;

public class HelpController : MonoBehaviour {
	public GameObject SubHelp;
	void Start () {
		SubHelp.SetActive (false);
	}

	void Update(){
		if (Input.GetKey (KeyCode.Escape)) {
			SubHelp.SetActive (false);
		}
	}

	public void LoadSubHelp(){
		SubHelp.SetActive (true);
	}
}
