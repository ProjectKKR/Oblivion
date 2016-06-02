using UnityEngine;
using System.Collections;

public class OptionControlTrigger: MonoBehaviour {

	public void Option1(){
		Static.SetControlOption (1);
	}
	public void Option2(){
		Static.SetControlOption (2);
	}
	public void Option3(){
		Static.SetControlOption (3);
	}
}
