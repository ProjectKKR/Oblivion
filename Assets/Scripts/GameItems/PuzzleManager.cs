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

	void Update(){
		animating = false;
		for (int i = 0; i < this.gameObject.transform.GetChild (1).transform.childCount; i++) {
			PuzzlePieceController ppc = this.gameObject.transform.GetChild (1).transform.GetChild(i). GetComponent<PuzzlePieceController> ();
			print (ppc);
			if (ppc == null)
				continue;
			animating = animating | ppc.moveFlag;
		}
	}

	public int Movable(GameObject piece){
		if (piece == null)
			return 0;
		if (animating)
			return 0;
		animating = true;
		int direction=0;
		currX = -1; currY = -1;
		for (int i = 0; i < 3; i++) {
			for (int j = 0; j < 3; j++) {
				if (blankX==i && blankY==j)
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
			direction = 3;

		// Can move Up
		else if (currX - 1 == blankX && currY == blankY)
			direction = 4;

		// Can move Down
		else if (currX + 1 == blankX && currY == blankY)
			direction = 2;
		if (direction == 0)
			return 0;
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