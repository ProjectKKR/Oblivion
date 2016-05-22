using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

public class FiniteMoveManager1: FiniteMoveManager {

	public override void Reset(){
		targetCoords.Clear (); unitCoords.Clear (); unitCounts.Clear ();
		targetCoords.Add (new Vector2 (6, 3));
		unitCoords.Add (new Vector2 (3, 3));
		unitCounts.Add (3);
		Refresh ();
	}
}