using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class PhoneClockText : MonoBehaviour {

	private Text clockText;
	void Start () {
		clockText = GetComponent<Text> ();
	}
	void Update () {
		System.DateTime time = System.DateTime.Now;
		clockText.text = time.ToString("HH : mm");
	}

}
