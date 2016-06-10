using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class FiniteMoveManager1: FiniteMoveManager {

	public override void Load() {
		if (PlayerPrefs.HasKey ("Finite_Move_Puzzle_Round1")) {
			gameObject.SetActive (PlayerPrefsX.GetBool ("Finite_Move_Puzzle_Round1"));
		}
	}

	public override void Reset(){
		targetCoords.Clear (); unitCoords.Clear (); unitCounts.Clear ();
		targetCoords.Add (new Vector2 (6, 3));
		unitCoords.Add (new Vector2 (3, 3));
		unitCounts.Add (3);
		Refresh ();
	}
}