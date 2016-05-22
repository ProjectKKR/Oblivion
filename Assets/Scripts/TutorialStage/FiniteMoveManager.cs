using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System.Collections.Generic;

public abstract class FiniteMoveManager : MonoBehaviour {
	public int N;
	public const float W = 57.325f;
	public GameObject nextButton, resetButton;
	public GameObject nextRound;
	public GameObject targets;
	public GameObject units;
	public List<GameObject> targetObjs = new List<GameObject>();
	public List<GameObject> unitObjs = new List<GameObject>();
	public List<Vector2> targetCoords = new List<Vector2> ();
	public List<Vector2> unitCoords = new List<Vector2> ();
	public List<int> unitCounts = new List<int> ();
	private Vector2[] dir = new Vector2[4]{new Vector2(1,0),new Vector2(0,1),new Vector2(-1,0),new Vector2(0,-1)};
	public abstract void Reset ();
	void Start () {
		targetObjs.Clear ();
		unitObjs.Clear ();
		for (int i = 0; i < N; i++) {
			targetObjs.Add (targets.transform.GetChild (i).gameObject);
			unitObjs.Add (units.transform.GetChild (i).gameObject);
		}
		Reset ();
	}
	// Use this for initialization
	Vector2 translate(Vector2 X){
		X.x--; X.y--;
		X = X * W + new Vector2 (W / 2, W / 2);
		X.x -= W * 4;
		X.y = W * 3 - X.y;
		return X;
	}
	int exist(Vector2 pos){
		for (int i=0;i<N;i++){
			if ((pos - unitCoords [i]).magnitude < 1)
				return i;
		}
		return -1;
	}
	public void MoveUnit(GameObject unit,int direction){
		int I=0;
		for (int i = 0; i < N; i++)
			if (unit.Equals (unitObjs [i]))
				I = i;
		if (unitCounts [I] == 0)
			return;
		Vector2 pos = unitCoords [I], save_pos=unitCoords[I];
		for (;;) {
			pos += dir [direction];
			if (exist (pos) == -1) {
				if (pos.x < 1 || pos.x > 8 || pos.y < 1 || pos.y > 6)
					break;
				unitCounts [I]--;
				for (; (pos-save_pos).magnitude>0.1f;) {
					pos -= dir [direction];
					unitCoords [exist (pos)] += dir [direction];
				}
				break;
			}
		}
		Refresh ();
		CheckAnswer ();
	}
	protected void Refresh(){
		for (int i = 0; i < N; i++) {
			targetObjs [i].transform.localPosition = translate (targetCoords [i]);
			unitObjs [i].transform.localPosition = translate (unitCoords [i]);
			unitObjs [i].transform.GetChild (0).GetComponent<Text> ().text = unitCounts [i].ToString ();
		}
		for (int i = 0; i < N; i++) {
			bool flag = false;
			for (int j = 0; j < N; j++) {
				if ((unitCoords [i] - targetCoords [j]).magnitude<0.1f){
					flag = true;
				}
			}
			if (flag)
				unitObjs [i].transform.GetComponent<RawImage> ().color = new Color (114.0f/255.0f, 118.0f/255.0f, 206.0f/255.0f);
			else
				unitObjs [i].transform.GetComponent<RawImage> ().color = new Color (1, 1, 1);
		}
	}
	protected void CheckAnswer(){
		for (int i = 0; i < N; i++) {
			if (unitCounts [i] != 0)
				return;
		}
		for (int i = 0; i < N; i++) {
			bool flag = false;
			for (int j = 0; j < N; j++) {
				if ((unitCoords [i] - targetCoords [j]).magnitude<0.1f){
					flag = true;
				}
			}
			if (!flag)
				return;
		}
		resetButton.SetActive (false);
		nextButton.SetActive (true);
	}
	public void NextRound(){
		nextRound.SetActive (true);
		this.gameObject.SetActive (false);
	}
}

/*
public void ClickInteraction (GameItems equipped) {
	if (interactable)
	if (EquippedItemCheck (equipped))
		Interaction ();
}
protected virtual bool EquippedItemCheck (GameItems equipped){
	return true;
}
public virtual void ChainOperation (int caseNum){}
protected abstract void Interaction ();

*/