using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class Computer : MonoBehaviour {
	private int inputCode = 0, N=4;
	private int[] activateCode=new int[4]{301314, 1920, 201411111, 2673985};
	private bool[] clearFlag = new bool[4]{false, false, false, false};
	private Text view;
	private Renderer[] redLight;
	private Renderer[] greenLight;
	public GameItems[] activateGameItems;
	public GameObject lights;
	public Material redLightOn, redLightOff, greenLightOn, greenLightOff;
	void Start(){
		view = GetComponent<Text> ();
		for (int i = 0; i < N; i++) {
			redLight[i] = lights.transform.GetChild (i).GetComponent<Renderer> ();
			greenLight[i] = lights.transform.GetChild (i + N).GetComponent<Renderer> ();
		}
	}
	public void PressEnter(){
		for (int i = 0; i < N; i++) {
			if (activateCode[i] == inputCode) {
				activateGameItems [i].interactable = true;
				clearFlag [i] = true;
			}
		}
		inputCode = 0;
		Refresh ();
	}
	public void Clear(){
		inputCode = 0;
		Refresh ();
	}
	public void Delete(){
		inputCode = inputCode / 10;
		Refresh ();
	}
	public void Add(int x){
		inputCode = inputCode * 10 + x;
		Refresh ();
	}
	private void Refresh(){
		view.text = inputCode.ToString();
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