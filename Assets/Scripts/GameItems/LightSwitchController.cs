using UnityEngine;
using System.Collections;

public class LightSwitchController : GameItems {
	
	//public LightController LC;
	public GameObject switchAxis;
	public GameObject ClockFace;
	public Light[] lights = new Light[4];

	private const float angle = 10;
	private bool state;

	public bool getState() {
		return state;
	}

	void Start () {
		state = false;
		if (PlayerPrefs.HasKey ("Light_Switch_Interactable")) {
			interactable = PlayerPrefsX.GetBool ("Light_Switch_Interactable");
		}

		if (PlayerPrefs.HasKey ("Light_Switch_State")) {
			state = PlayerPrefsX.GetBool ("Light_Switch_State");
			for (int i = 0; i < 4; i++) {
				lights [i].intensity = state ? 0.1f : 0.3f;
			}
			switchAxis.transform.eulerAngles = new Vector3 (90, 0, state ? -angle : 0);
		}

		if (PlayerPrefs.HasKey ("Clock_Face_Active")) {
			ClockFace.SetActive (PlayerPrefsX.GetBool ("Clock_Face_Active"));
		}
	}

	protected override void Interaction () {
		state = !state;
		switchAxis.transform.eulerAngles = new Vector3 (90, 0, state ? -angle : 0);
		ClockFace.SetActive (state);
		for (nint i = 0; i < 4; i++) {
			lights [i].intensity = state ? 0.1f : 0.3f;
		}
		//LC.Light (state);
	}
}