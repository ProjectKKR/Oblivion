using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class FiniteMoveManager4: FiniteMoveManager {

	public override void Load() {
		if (PlayerPrefs.HasKey ("Finite_Move_Puzzle_Round4")) {
			gameObject.SetActive (PlayerPrefsX.GetBool ("Finite_Move_Puzzle_Round4"));
		}
	}

	public override void Reset(){
		targetCoords.Clear (); unitCoords.Clear (); unitCounts.Clear ();
		targetCoords.Add (new Vector2 (2, 4));
		targetCoords.Add (new Vector2 (3, 3));
		targetCoords.Add (new Vector2 (4, 4));
		targetCoords.Add (new Vector2 (5, 4));
		targetCoords.Add (new Vector2 (5, 5));
		targetCoords.Add (new Vector2 (6, 3));
		unitCoords.Add (new Vector2 (3, 2));
		unitCoords.Add (new Vector2 (3, 3));
		unitCoords.Add (new Vector2 (3, 4));
		unitCoords.Add (new Vector2 (5, 2));
		unitCoords.Add (new Vector2 (5, 3));
		unitCoords.Add (new Vector2 (5, 4));
		unitCounts.Add (2);
		unitCounts.Add (2);
		unitCounts.Add (1);
		unitCounts.Add (3);
		unitCounts.Add (0);
		unitCounts.Add (0);
		Refresh ();
	}
}