using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class DigitalClock : GameItems {

	private Text clockText;

	// Use this for initialization
	void Start () {
		clockText = GetComponent<Text> ();
	}
	
	// Update is called once per frame
	void Update () {
		System.DateTime time = System.DateTime.Now;

		clockText.text = time.ToString("hh:mm"); 
	}


	protected override bool EquippedItemCheck(GameItems equipped) {
		return equipped.GetType ().Equals (Umbrella);
	}

	protected override void Interaction() {
		;
	}

	protected override void PostProcess() {
		;
	}

}
