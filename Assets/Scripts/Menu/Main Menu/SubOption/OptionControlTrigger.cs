using UnityEngine;
using System.Collections;

public class OptionControlTrigger: MonoBehaviour {
	public GameObject checkbox;

	void Start() {
		if (PlayerPrefs.HasKey ("Control_Option")) {
			switch (PlayerPrefs.GetInt ("Control_Option")) {
			case 1:
				Option1 ();
				break;
			case 2:
				Option2 ();
				break;
			case 3:
				Option3 ();
				break;
			}
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

	public void Option1(){
		Static.SetControlOption (1);
		CheckBoxReposition();
		PlayerPrefs.SetInt ("Control_Option", 1);
	}
	public void Option2(){
		Static.SetControlOption (2);
		CheckBoxReposition ();
		PlayerPrefs.SetInt ("Control_Option", 2);
	}
	public void Option3(){
		Static.SetControlOption (3);
		CheckBoxReposition ();
		PlayerPrefs.SetInt ("Control_Option", 3);
	}
}
