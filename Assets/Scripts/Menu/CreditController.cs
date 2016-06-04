using UnityEngine;
using System.Collections;

public class CreditController : MonoBehaviour {
	public GameObject SubCredit;
	void Start () {
		SubCredit.SetActive (false);
	}

	void Update(){
		if (Input.GetKey (KeyCode.Escape)) {
			SubCredit.SetActive (false);
		}
	}

	public void LoadSubCredit(){
		SubCredit.SetActive (true);
	}
}
