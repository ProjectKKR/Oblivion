using UnityEngine;
using System.Collections;

public class PuzzleControl : GameItems
{
    public GameObject[,] pieces = new GameObject[3, 3];

    private int blankX = 2, blankY = 2;

    private bool animating = false;
    private int animateX, animateY;
    private int animateCount = 0;
    private int maxCount = 10;
    private float animateSpeed = 0.160256f / 10;
    private char direction;
	private Ray ray;
	private RaycastHit hit;
    
    void Start()
    {
        for (int i = 0; i < 3; i++)
        {
            for (int j = 0; j < 3; j++)
            {
                if (i == 2 && j == 2)
                {
                    pieces[i, j] = null;
                    continue;
                }
                pieces[i, j] = GameObject.Find("Piece" + (3 * i + j + 1).ToString());
            }
        }
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0) && !animating)
        {
			ray = Camera.main.ScreenPointToRay(Input.mousePosition);
			int currX = -1, currY = -1;

			if(Physics.Raycast(ray, out hit, Mathf.Infinity)){
				for (int i = 0; i < 3; i++) {
					for (int j = 0; j < 3; j++) {
						if (pieces [i, j] == null)
							continue;
						if (hit.transform.gameObject.Equals(pieces [i, j].gameObject)) {
							currX = i;
							currY = j;
						}
					}
				}
			}

            // Can move Right
            
            if (currX == blankX && currY + 1 == blankY)
            {
                animating = true;
                animateX = currX;
                animateY = currY;
                animateCount = 0;
                direction = 'r';
            }

            // Can move Left

            else if (currX == blankX && currY - 1 == blankY)
            {
                animating = true;
                animateX = currX;
                animateY = currY;
                animateCount = 0;
                direction = 'l';
            }

            // Can move Up

            else if (currX - 1 == blankX && currY == blankY)
            {
                animating = true;
                animateX = currX;
                animateY = currY;
                animateCount = 0;
                direction = 'u';
            }

            // Can move Down

            else if (currX + 1 == blankX && currY == blankY)
            {
                animating = true;
                animateX = currX;
                animateY = currY;
                animateCount = 0;
                direction = 'd';
            }
        }
    }

    void FixedUpdate()
    {
        if (animating)
        {
			if (direction == 'r') pieces[animateX, animateY].transform.Translate(animateSpeed, 0, 0);
			else if (direction == 'l') pieces[animateX, animateY].transform.Translate(-animateSpeed, 0, 0);
            else if (direction == 'u') pieces[animateX, animateY].transform.Translate(0, 0, animateSpeed);
			else if (direction == 'd') pieces[animateX, animateY].transform.Translate(0, 0, -animateSpeed);
            
            animateCount++;
            if (animateCount >= maxCount)
            {
                animating = false;
                animateCount = 0;
                pieces[blankX, blankY] = pieces[animateX, animateY];
                pieces[animateX, animateY] = null;
                blankX = animateX;
                blankY = animateY;
            }
        }
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