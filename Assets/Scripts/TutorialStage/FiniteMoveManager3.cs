using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class FiniteMoveManager3: FiniteMoveManager {

	public override void Load() {
		if (PlayerPrefs.HasKey ("Finite_Move_Puzzle_Round3")) {
			gameObject.SetActive (PlayerPrefsX.GetBool ("Finite_Move_Puzzle_Round3"));
		}
	}

	public override void Reset(){
		targetCoords.Clear (); unitCoords.Clear (); unitCounts.Clear ();
		targetCoords.Add (new Vector2 (4, 3));
		targetCoords.Add (new Vector2 (4, 4));
		targetCoords.Add (new Vector2 (5, 2));
		targetCoords.Add (new Vector2 (5, 3));
		targetCoords.Add (new Vector2 (5, 5));
		targetCoords.Add (new Vector2 (6, 3));
		targetCoords.Add (new Vector2 (6, 4));
		unitCoords.Add (new Vector2 (2, 3));
		unitCoords.Add (new Vector2 (3, 3));
		unitCoords.Add (new Vector2 (4, 2));
		unitCoords.Add (new Vector2 (4, 5));
		unitCoords.Add (new Vector2 (5, 3));
		unitCoords.Add (new Vector2 (5, 4));
		unitCoords.Add (new Vector2 (6, 2));
		unitCounts.Add (2);
		unitCounts.Add (0);
		unitCounts.Add (1);
		unitCounts.Add (2);
		unitCounts.Add (0);
		unitCounts.Add (2);
		unitCounts.Add (1);
		Refresh ();
	}
}