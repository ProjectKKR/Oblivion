using UnityEngine;
using System.Collections;

public class PuzzlePieceController : GameItems {
	public PuzzleManager manager;
	public bool moveFlag;

	private int animateCount = 0;
	private int maxCount = 10;
	private float animateSpeed = 0.160256f / 10;
	private int dir;
	// Use this for initialization
	void Start () {
		setLocation (manager.transform.position + new Vector3 (-1.5f, 0, 0));
		setRotation (Quaternion.Euler (new Vector3 (0, 90, 0)));
		dir = 0;
		moveFlag = false;
	}

	void Update () {
		if (moveFlag && manager.animating)
		{
			if (dir == 1) this.gameObject.transform.Translate(animateSpeed, 0, 0);
			else if (dir== 3) this.gameObject.transform.Translate(-animateSpeed, 0, 0);
			else if (dir== 2) this.gameObject.transform.Translate(0, 0, -animateSpeed);
			else if (dir== 4) this.gameObject.transform.Translate(0, 0, animateSpeed);

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
		if (manager.animating || moveFlag) {
			return;
		}
		dir = manager.Movable (this.gameObject);
		if (dir == 0)
			return;
		moveFlag = true;
	}
	protected override void PostProcess () {
		;
	}
}
