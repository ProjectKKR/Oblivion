using UnityEngine;
using System.Collections;

public class FiniteMovePuzzleScreen : GameItems {

	private GameObject[] rounds = new GameObject[6];

	// Use this for initialization
	void Start () {
		zoomLocation = transform.position + new Vector3 (0, 0.8f, 0);
		zoomRotation = Quaternion.Euler (new Vector3 (90, 0, 0));

		for (int i = 0; i < 6; i++) {
			rounds [i] = transform.GetChild (i).gameObject;
		}

		if (PlayerPrefs.HasKey ("Finite_Move_Puzzle_Round1")) {
			rounds[0].SetActive (PlayerPrefsX.GetBool ("Finite_Move_Puzzle_Round1"));
		}
		if (PlayerPrefs.HasKey ("Finite_Move_Puzzle_Round2")) {
			rounds[1].SetActive (PlayerPrefsX.GetBool ("Finite_Move_Puzzle_Round2"));
		}
		if (PlayerPrefs.HasKey ("Finite_Move_Puzzle_Round3")) {
			rounds[2].SetActive (PlayerPrefsX.GetBool ("Finite_Move_Puzzle_Round3"));
		}
		if (PlayerPrefs.HasKey ("Finite_Move_Puzzle_Round4")) {
			rounds[3].SetActive (PlayerPrefsX.GetBool ("Finite_Move_Puzzle_Round4"));
		}
		if (PlayerPrefs.HasKey ("Finite_Move_Puzzle_Round5")) {
			rounds[4].SetActive (PlayerPrefsX.GetBool ("Finite_Move_Puzzle_Round5"));
		}
		if (PlayerPrefs.HasKey ("Finite_Move_Puzzle_Clear")) {
			rounds[5].SetActive (PlayerPrefsX.GetBool ("Finite_Move_Puzzle_Clear"));
		}
	}

	protected override void Interaction () {
	}
}
