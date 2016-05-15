using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class LoadingMessage : MonoBehaviour {
	private Text loadingMessage;
	// Use this for initialization
	void Start () {
		loadingMessage = GetComponent<Text> ();
		loadingMessage.text = "Now Loading";
	}


}
