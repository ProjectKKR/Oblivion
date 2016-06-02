using UnityEngine;
using System.Collections;

public class OptionController : MonoBehaviour {
	public GameObject SubOption;
	// Use this for initialization
	void Start () {
		SubOption.SetActive (false);
	}
	public void LoadSubOption(){
		SubOption.SetActive (true);
	}
}
