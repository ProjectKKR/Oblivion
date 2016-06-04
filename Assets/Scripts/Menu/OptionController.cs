using UnityEngine;
using System.Collections;

public class OptionController : MonoBehaviour {
	public GameObject SubOption;
	public GameObject checkbox;
	// Use this for initialization
	void Start () {
		SubOption.SetActive (false);
	}

	void Update(){
		if (Input.GetKey (KeyCode.Escape)) {
			SubOption.SetActive (false);
		}
	}

	public void CheckBoxReposition(){
		switch (Static.GetControlOption()) {
		case 1:
			checkbox.transform.localPosition = new Vector3 (-350, 5, 0);
			break;
		case 2:
			checkbox.transform.localPosition = new Vector3 (-3, 5, 0);
			break;
		case 3:
			checkbox.transform.localPosition = new Vector3 (367, 5, 0);
			break;
		}
	}
	public void LoadSubOption(){
		SubOption.SetActive (true);
		CheckBoxReposition ();
	}
}
