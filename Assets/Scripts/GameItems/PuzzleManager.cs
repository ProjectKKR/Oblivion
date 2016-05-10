using UnityEngine;
using System.Collections;

public class PuzzleManager : GameItems {
	public GameObject[,] pieces = new GameObject[3, 3];
	public int[,] sol = new int[3, 3];
	public GameObject[,] solution = new GameObject[3, 3];
	public GameItems door;

	private int blankX = 2, blankY = 2;

	public bool animating = false;
	public bool solveFlag = false;
	private int currX, currY;
	// Use this for initialization
	void Start () {
		zoomLocation = transform.position + new Vector3 (-1.5f, 0, 0);
		zoomRotation = Quaternion.Euler (new Vector3 (0, 90, 0));

		/*sol [0, 0] = 8; sol [0, 1] = 6; sol [0, 2] = 1;
		sol [1, 0] = 7; sol [1, 1] = 5; sol [1, 2] = 3;
		sol [2, 0] = 4; sol [2, 1] = 2; sol [2, 2] = 0;*/
		sol [0, 0] = 1; sol [0, 1] = 2; sol [0, 2] = 3;
		sol [1, 0] = 4; sol [1, 1] = 6; sol [1, 2] = 8;
		sol [2, 0] = 7; sol [2, 1] = 5; sol [2, 2] = 0;

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
		for (int i = 0; i < 3; i++) {
			for (int j = 0; j < 3; j++) {
				solution [i, j] = GameObject.Find ("Piece" + sol [i, j].ToString ());
			}
		}
	}

	public void CheckAnswer(){
		int cnt = 0;
		bool flag = true;
		for (int i = 0; i < 3; i++) {
			for (int j = 0; j < 3; j++) {
				if (solution [i, j] == null || pieces [i, j] == null) {
					continue;
				}
				if (solution [i, j].Equals (pieces [i, j]))
					cnt++;
			}
		}
		flag = (cnt == 8);
		if (flag) {
			PostProcess ();
		}
	}

	void Update(){
		if (solveFlag)
			return;
		// TODO : NEED OPTIMIZE
		animating = false;
		for (int i = 0; i < this.gameObject.transform.GetChild (1).transform.childCount; i++) {
			PuzzlePieceController ppc = this.gameObject.transform.GetChild (1).GetChild(i). GetComponent<PuzzlePieceController> ();
			if (ppc == null)
				continue;
			animating = animating | ppc.moveFlag;
		}
	}

	public int Movable(GameObject piece){
		if (solveFlag)
			return 0;
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
	protected override void Interaction () {
	}
	protected void PostProcess () {
		solveFlag = true;
		zoomable = false;
		interactable = false;
		for (int i = 0; i < this.gameObject.transform.GetChild (1).transform.childCount; i++) {
			PuzzlePieceController ppc = this.gameObject.transform.GetChild (1).GetChild(i). GetComponent<PuzzlePieceController> ();
			ppc.interactable = false;
		}
		door.interactable = true;
	}
}