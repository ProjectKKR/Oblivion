using UnityEngine;
using System.Collections;

public class PuzzlePieceController : GameItems {
	public PuzzleManager manager;

	private int animateCount = 0;
	private int maxCount = 10;
	private float animateSpeed = 0.160256f / 10;
	private bool moveFlag;
	private int dir;
	// Use this for initialization
	void Start () {
		setLocation (manager.transform.position + new Vector3 (-1.5f, 0, 0));
		setRotation (Quaternion.Euler (new Vector3 (0, 90, 0)));
		dir = 0;
		moveFlag = false;
	}

	void FixUpdate () {
		if (moveFlag)
		{
			if (dir == 1) this.gameObject.transform.Translate(animateSpeed, 0, 0);
			else if (dir== 3) this.gameObject.transform.Translate(-animateSpeed, 0, 0);
			else if (dir== 4) this.gameObject.transform.Translate(0, 0, animateSpeed);
			else if (dir== 2) this.gameObject.transform.Translate(0, 0, -animateSpeed);
			print (animateCount);
			animateCount++;
			if (animateCount >= maxCount)
			{
				animateCount = 0;
				dir = 0;
				moveFlag = false;
				manager.animating = false;
			}
		}
	}
	protected override bool EquippedItemCheck(GameItems equipped) {
		return true;
	}

	protected override void Interaction () {
		if (manager.animating)
			return;
		dir = manager.Movable (this.gameObject);
		if (dir == 0)
			return;
		moveFlag = true;
	}
	protected override void PostProcess () {
		;
	}
}
