using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class SmartPhone : MonoBehaviour {
	public Text view;

	private string activateCode = "201416371";
	private int[] inputCode = new int[10];
	private int len = 0, N = 4;
	private bool clearFlag;

	void Start(){

		Refresh ();
	}
	string translate(){
		string t = "";
		for (int i = 1; i <= len; i++) {
			t = t + inputCode [i].ToString ();
		}
		return t;
	}
	public void PressEnter(){
		for (int i = 0; i < N; i++) {
			if (activateCode == translate()) {
				clearFlag = true;
			}
		}
		len = 0;
		Refresh ();
	}
	public void Delete(){
		if (len>=1) len--;
		Refresh ();
	}
	public void Add(int x){
		if (len == 9)
			return;
		inputCode [++len] = x;
		Refresh ();
	}
	private void Refresh(){
		view.text = null;
		for (int i = 1; i <= len; i++) {
			view.text = view.text + inputCode [i].ToString ();
		}
	}
}