using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class FiniteMoveManager2: FiniteMoveManager {

	public override void Load() {
		if (PlayerPrefs.HasKey ("Finite_Move_Puzzle_Round2")) {
			gameObject.SetActive (PlayerPrefsX.GetBool ("Finite_Move_Puzzle_Round2"));
		}
	}

	public override void Reset(){
		targetCoords.Clear (); unitCoords.Clear (); unitCounts.Clear ();
		targetCoords.Add (new Vector2 (5, 2));
		targetCoords.Add (new Vector2 (3, 3));
		targetCoords.Add (new Vector2 (4, 4));
		unitCoords.Add (new Vector2 (4, 3));
		unitCoords.Add (new Vector2 (5, 3));
		unitCoords.Add (new Vector2 (4, 4));
		unitCounts.Add (0);
		unitCounts.Add (2);
		unitCounts.Add (2);
		Refresh ();
	}
}