using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class SmartPhone : MonoBehaviour {
	public Text view;
	public Text dialview;
	public GameObject passwordScreen;
	public GameObject mainMenuScreen;
	public GameObject dialScreen;
	public GameObject messageScreen;
	public GameObject galleryScreen;

	private const int DIALMAX = 15;
	private char[] callDial = new char[DIALMAX];
	private int dialLen = 0;
	private const string dialAnswer = "23456789";

	private string activateCode = "201416371";
	private int[] inputCode = new int[10];
	private int len = 0, N = 4;
	public int currentState;

	private const int DEFAULT = 0;
	private const int PW = 1;
	private const int MAINMENU = 2;
	private const int DIAL = 3;
	private const int MESSAGE = 4;
	private const int GALLERY = 5;

	void Start(){
		currentState = DEFAULT;
		Refresh ();
	}

	string Translate(){
		string t = "";
		for (int i = 1; i <= len; i++) {
			t = t + inputCode [i].ToString ();
		}
		return t;
	}

	public void PressEnter(){
		for (int i = 0; i < N; i++) {
			if (activateCode == Translate()) {
				OpenApp (MAINMENU);
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
		if (currentState == PW) {
			view.text = null;
			for (int i = 1; i <= len; i++) {
				view.text = view.text + inputCode [i].ToString ();
			}
		} else if (currentState == DIAL) {
			dialview.text = "";
			for (int i = 0; i < dialLen; i++) {
				dialview.text = dialview.text + callDial [i].ToString ();
			}
		}
	}

	public void OpenApp(int appnum) {
		passwordScreen.SetActive (false);

		mainMenuScreen.SetActive (false);
		dialScreen.SetActive (false);
		messageScreen.SetActive (false);
		galleryScreen.SetActive (false);
		switch (appnum) {
		case MAINMENU:
			mainMenuScreen.SetActive (true);
			break;
		case DIAL:
			dialScreen.SetActive (true);
			break;
		case MESSAGE:
			messageScreen.SetActive (true);
			break;
		case GALLERY:
			galleryScreen.SetActive (true);
			break;
		default:
			passwordScreen.SetActive (true);
			break;
		}
		currentState = appnum;
	}

	public void Dial(int number) {
		if (dialLen == DIALMAX - 1)
			return;
		char c;
		if (0 <= number && number <= 9)
			c = (char) (number + 48);
		else if (number == 10)
			c = '*';
		else
			c = '#';
		callDial [dialLen++] = c;
		Refresh ();
	}

	public void DialDelete() {
		if (dialLen > 0) {
			dialLen--;
		}
		Refresh ();
	}

	public void Call() {
		string t = "";
		for (int i = 0; i < dialLen; i++) {
			t = t + callDial [i];
		}
		if (t.Equals (dialAnswer)) {
			;// CALL
		} else {
			// WRONG NUMBER
			dialLen = 0;
		}
	}
}