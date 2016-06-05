using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using System.Collections;

public class ComputerButton: MonoBehaviour{
	private Computer com;
	public int number;
	void Start(){
		com = transform.parent.GetComponent<Computer>();
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