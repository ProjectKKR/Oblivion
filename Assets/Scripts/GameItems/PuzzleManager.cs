using UnityEngine;
using System.Collections;

public class PuzzleManager : GameItems {
	public GameObject[,] pieces = new GameObject[3, 3];

	private int blankX = 2, blankY = 2;

	public bool animating = false;
	private int currX, currY;
	// Use this for initialization
	void Start () {
		setLocation (transform.position + new Vector3 (-1.5f, 0, 0));
		setRotation (Quaternion.Euler (new Vector3 (0, 90, 0)));

		for (int i = 0; i < 3; i++)
		{
			for (int j = 0; j < 3; j++)
			{
				if (i == blankX && j == blankY)
				{
					pieces[i, j] = null;
					continue;
				}
				pieces[i, j] = GameObject.Find("Piece" + (3 * i + j + 1).ToString());
			}
		}
	}

	public int Movable(GameObject piece){
		if (animating)
			return 0;
		int direction=0;
		currX = -1; currY = -1;
		for (int i = 0; i < 3; i++) {
			for (int j = 0; j < 3; j++) {
				if (pieces [i, j] == null)
					continue;
				if (piece.Equals(pieces [i, j].gameObject)) {
					currX = i;
					currY = j;
				}
			}
		}
		// Can move Right
		if (currX == blankX && currY + 1 == blankY)
			direction = 1;

		// Can move Left
		else if (currX == blankX && currY - 1 == blankY)
			direction = 2;

		// Can move Up
		else if (currX - 1 == blankX && currY == blankY)
			direction = 3;

		// Can move Down
		else if (currX + 1 == blankX && currY == blankY)
			direction = 4;
		animating = true;
		pieces[blankX, blankY] = pieces[currX, currY];
		pieces[currX, currY] = null;
		blankX = currX;
		blankY = currY;
		return direction;
	}

	public void Zoom(){
		
	}

	protected override bool EquippedItemCheck(GameItems equipped) {
		return true;
	}

	protected override void Interaction () {
		// TODO
	}
	protected override void PostProcess () {
		;
	}
}