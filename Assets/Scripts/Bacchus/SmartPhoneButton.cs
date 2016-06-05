using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using System.Collections;

public class SmartPhoneButton: MonoBehaviour{
	private SmartPhone com;
	public int number;
	void Start(){
		com = transform.parent.GetComponent<SmartPhone>();
	}
	public void NumberButton(){
		com.Add (number);
	}
	public void DeleteButton(){
		com.Delete ();
	}
	public void EnterButton(){
		com.PressEnter ();
	}
}