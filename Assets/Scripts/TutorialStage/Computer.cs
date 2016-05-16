using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class Computer : MonoBehaviour {
	public Text view;
	public GameItems[] activateGameItems = new GameItems[4];
	public GameObject lights;
	public Material redLightOn, redLightOff, greenLightOn, greenLightOff;

	private int[] inputCode = new int[10];
	private int len = 0, N = 4;
	private string[] activateCode=new string[4]{"301314", "1920", "201411111", "2673985"};
	private bool[] clearFlag = new bool[4]{false, false, false, false};
	private Renderer[] redLight = new Renderer[4];
	private Renderer[] greenLight = new Renderer[4];
	void Start(){
		for (int i = 0; i < N; i++) {
			redLight[i] = lights.transform.GetChild (i).GetComponent<Renderer> ();
			greenLight[i] = lights.transform.GetChild (i + N).GetComponent<Renderer> ();
		}
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
			if (activateCode[i] == translate()) {
				activateGameItems [i].interactable = true;
				clearFlag [i] = true;
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
		for (int i = 0; i < N; i++) {
			if (clearFlag [i]) {
				redLight [i].sharedMaterial = redLightOff;
				greenLight [i].sharedMaterial = greenLightOn;
			} else {
				redLight [i].sharedMaterial = redLightOn;
				greenLight [i].sharedMaterial = greenLightOff;
			}
		}
	}
}