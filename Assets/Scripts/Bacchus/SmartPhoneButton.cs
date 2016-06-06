using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using System.Collections;

public class SmartPhoneButton: MonoBehaviour{
	private SmartPhone com;
	public int number;
	void Start(){
		com = transform.parent.parent.GetComponent<SmartPhone>();
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
	public void DialButton() {
		com.Dial (number);
	}
	public void DialDeleteButton() {
		com.DialDelete ();
	}
	public void AppButton() {
		com.OpenApp (number);
	}
	public void CallButton() {
		com.Call ();
	}
}