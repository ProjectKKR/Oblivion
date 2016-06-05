using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class FiniteMoveManager5: FiniteMoveManager {

	public override void Load() {
		if (PlayerPrefs.HasKey ("Finite_Move_Puzzle_Round5")) {
			gameObject.SetActive (PlayerPrefsX.GetBool ("Finite_Move_Puzzle_Round5"));
		}
	}

	public override void Reset(){
		targetCoords.Clear (); unitCoords.Clear (); unitCounts.Clear ();
		targetCoords.Add (new Vector2 (2, 3));
		targetCoords.Add (new Vector2 (3, 4));
		targetCoords.Add (new Vector2 (4, 2));
		targetCoords.Add (new Vector2 (4, 3));
		targetCoords.Add (new Vector2 (4, 5));
		targetCoords.Add (new Vector2 (5, 2));
		targetCoords.Add (new Vector2 (6, 3));
		unitCoords.Add (new Vector2 (2, 3));
		unitCoords.Add (new Vector2 (3, 1));
		unitCoords.Add (new Vector2 (4, 2));
		unitCoords.Add (new Vector2 (4, 4));
		unitCoords.Add (new Vector2 (4, 5));
		unitCoords.Add (new Vector2 (5, 3));
		unitCoords.Add (new Vector2 (6, 2));
		unitCounts.Add (2);
		unitCounts.Add (3);
		unitCounts.Add (1);
		unitCounts.Add (2);
		unitCounts.Add (2);
		unitCounts.Add (1);
		unitCounts.Add (3);
		Refresh ();
	}
}