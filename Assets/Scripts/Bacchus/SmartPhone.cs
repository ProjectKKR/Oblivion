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
	public GameObject callingScreen;
	public GameObject callFinished;
	public GameObject enterButton;
	public GameObject menuButton;
	public GameObject statusBar;
	public GameObject messageIcon;
	public GameObject messageNumber;
	public GameObject message;
	public GameObject messageButton;
	public Text messageDate;

	public GameObject messageCheckScreen;
	public GameItems mainDoor;


	private const int DIALMAX = 15;
	private char[] callDial = new char[DIALMAX];
	private int dialLen = 0;
	private const string dialAnswer = "0"; // 01041416486

	private string activateCode = "2"; // 201416371
	private int[] inputCode = new int[10];
	private int len = 0, N = 4;
	public int currentState;

	private const int DEFAULT = 0;
	private const int PW = 1;
	private const int MAINMENU = 2;
	private const int DIAL = 3;
	private const int MESSAGE = 4;
	private const int GALLERY = 5;
	private const int CALLING = 6;
	private const int MESSAGECHECK = 7;

	private bool messageReceived = false;

	public string getCallDial() {
		string ret = "";
		for (int i = 0; i < dialLen; i++)
			ret = ret + callDial [i].ToString ();
		return ret;
	}

	public void setCallDial(string s) {
		for (int i = 0; i < DIALMAX && i < s.Length; i++)
			callDial [i] = s[i];
	}

	public int getDialLen() {
		return dialLen;
	}

	public int[] getInputCode() {
		return inputCode;
	}

	public int getLen() {
		return len;
	}

	public bool getMessageReceived() {
		return messageReceived;
	}

	public string getMessageDate() {
		return messageDate.text;
	}

	void Start(){
		currentState = DEFAULT;

		if (PlayerPrefs.HasKey ("Phone_State")) {
			currentState = PlayerPrefs.GetInt ("Phone_State");
			OpenApp (currentState);
		}

		if (PlayerPrefs.HasKey ("Phone_Call_Dial")) {
			setCallDial (PlayerPrefs.GetString ("Phone_Call_Dial"));
		}

		if (PlayerPrefs.HasKey ("Phone_Dial_Len")) {
			dialLen = PlayerPrefs.GetInt ("Phone_Dial_Len");
		}

		if (PlayerPrefs.HasKey ("Phone_Input_Code")) {
			inputCode = PlayerPrefsX.GetIntArray ("Phone_Input_Code");
		}

		if (PlayerPrefs.HasKey ("Phone_Len")) {
			len = PlayerPrefs.GetInt ("Phone_Len");
		}

		if (PlayerPrefs.HasKey ("Phone_Message_Received")) {
			messageReceived = PlayerPrefsX.GetBool ("Phone_Message_Received");
		}

		if (PlayerPrefs.HasKey ("Phone_Message_Date")) {
			messageDate.text = PlayerPrefs.GetString ("Phone_Message_Date");
		}

		if (PlayerPrefs.HasKey ("Phone_Message_Icon_Active")) {
			messageIcon.SetActive (PlayerPrefsX.GetBool ("Phone_Message_Icon_Active"));
		}

		if (PlayerPrefs.HasKey ("Phone_Message_Number_Active")) {
			messageNumber.SetActive (PlayerPrefsX.GetBool ("Phone_Message_Number_Active"));
		}

		if (PlayerPrefs.HasKey ("Phone_Message_Active")) {
			message.SetActive (PlayerPrefsX.GetBool ("Phone_Message_Active"));
		}

		if (PlayerPrefs.HasKey ("Phone_Message_Button_Active")) {
			messageButton.SetActive (PlayerPrefsX.GetBool ("Phone_Message_Button_Active"));
		}
		Refresh ();
	}

	string Translate(){
		string t = "";
		if (currentState == PW) {
			for (int i = 1; i <= len; i++) {
				t = t + inputCode [i].ToString ();
			}
		} else if (currentState == DIAL) {
			for (int i = 0; i < dialLen; i++) {
				t = t + callDial [i].ToString ();
			}
		}
		return t;
	}

	public void PressEnter(){
		if (currentState == PW && activateCode.Equals (Translate ())) {
			OpenApp (MAINMENU);
		}
		len = 0;
		Refresh ();
	}

	public void PressDialEnter(){
		if (currentState == DIAL && dialAnswer.Equals (Translate ())) {
			// TODO SOUND ON
			callFinished.SetActive (false);
			enterButton.SetActive (true);
			menuButton.SetActive (false);
			OpenApp (CALLING);
			System.DateTime time = System.DateTime.Now;
			messageDate.text = time.ToString ("yyyy / M / d");
			Invoke ("AutomaticCallEnter", 3.0f);
		}
		dialLen = 0;
		Refresh ();
	}

	public void PressCallEnter(){
		if (currentState == CALLING) {
			//TODO SOUND OFF
			callFinished.SetActive (true);
			enterButton.SetActive (false);
			menuButton.SetActive (true);
			Invoke ("CallFinishedOff", 0.5f);
			Invoke ("CallFinishedOn", 1.0f);
			Invoke ("CallFinishedOff", 1.5f);
			Invoke ("CallFinishedOn", 2.0f);
			if (!messageReceived) {
				messageReceived = true;
				messageIcon.SetActive (true);
				messageNumber.SetActive (true);
				message.SetActive (true);
				messageButton.SetActive (true);
			}
		}
	}

	// same code with PressCallEnter...
	public void AutomaticCallEnter(){
		if (currentState == CALLING) {
			//TODO SOUND OFF
			if (callFinished.activeSelf) return;
			callFinished.SetActive (true);
			enterButton.SetActive (false);
			menuButton.SetActive (true);
			Invoke ("CallFinishedOff", 0.5f);
			Invoke ("CallFinishedOn", 1.0f);
			Invoke ("CallFinishedOff", 1.5f);
			Invoke ("CallFinishedOn", 2.0f);
			if (!messageReceived) {
				messageReceived = true;
				messageIcon.SetActive (true);
				messageNumber.SetActive (true);
				message.SetActive (true);
				messageButton.SetActive (true);
			}
		}
	}

	private void CallFinishedOn() {
		callFinished.SetActive (true);
	}

	private void CallFinishedOff() {
		callFinished.SetActive (false);
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
		print (appnum);
		if (appnum == GALLERY)
			return;
		dialview.text = "";

		passwordScreen.SetActive (false);
		mainMenuScreen.SetActive (false);
		dialScreen.SetActive (false);
		messageScreen.SetActive (false);
		galleryScreen.SetActive (false);
		callingScreen.SetActive (false);
		messageCheckScreen.SetActive (false);
		switch (appnum) {
		case MAINMENU:
			mainMenuScreen.SetActive (true);
			statusBar.SetActive (true);
			break;
		case DIAL:
			dialScreen.SetActive (true);
			statusBar.SetActive (true);
			break;
		case MESSAGE:
			messageScreen.SetActive (true);
			statusBar.SetActive (true);
			break;
		case GALLERY:
			galleryScreen.SetActive (true);
			statusBar.SetActive (true);
			break;
		case CALLING:
			callingScreen.SetActive (true);
			statusBar.SetActive (true);
			break;
		case MESSAGECHECK:
			messageCheckScreen.SetActive (true);
			statusBar.SetActive (true);
			messageIcon.SetActive (false);
			messageNumber.SetActive (false);
			mainDoor.interactable = true;
			break;
		default:
			passwordScreen.SetActive (true);
			statusBar.SetActive (true);
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
			OpenApp(CALLING);// CALL
		} else {
			// WRONG NUMBER
			dialLen = 0;
		}
	}
}