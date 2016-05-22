using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class NumberJump : GameItems {
	public GameObject clearPanel;
	public GameObject buttonSet;
	private Button[,] buttons = new Button[3,3];
	private const int N = 3;
	private int[,] visit = new int[3, 3];
	private int[,] num = {{1,2,2},{-1,1,3},{4,1,1}};

	private int lastX,lastY;
	// Use this for initialization
	void Start () {
		for (int i = 0; i < N; i++) {
			for (int j = 0; j < N; j++) {
				buttons [i, j] = buttonSet.transform.GetChild (i * 3 + j).GetComponent<Button>();
			}
		}
		PressReset ();
	}
	bool ClearCheck(){
		for (int i = 0; i < N; i++)
			for (int j = 0; j < N; j++)
				if (visit [i, j] == 0)
					return false;
		return true;
	}

	public void PressButton(int number){
		int x = number / N;
		int y = number % N;
		if (lastX == -1 && lastY == -1) {
			lastX = x;
			lastY = y;
			visit [x, y] = 1;
		}
		else if (distance (x, y) == num [lastX, lastY]) {
			lastX = x;
			lastY = y;
			visit [x, y] = 1;
		} else {
			return;
		}
		if (ClearCheck ()) {
			clearPanel.SetActive (true);
		}
		Refresh ();
	}
	public void PressReset(){
		for (int i = 0; i < N; i++) {
			for (int j = 0; j < N; j++) {
				visit [i,j] = 0;
			}
		}
		lastX = -1; lastY = -1;
		Refresh ();
	}
	private void Refresh(){
		for (int i = 0; i < N; i++) {
			for (int j = 0; j < N; j++) {
				if (lastX==-1 || distance (i, j) != num [lastX, lastY]) {
					ColorBlock CB = buttons [i, j].colors;
					CB.normalColor = new Color (0.913f, 0.913f, 0.913f, 1.0f);
					buttons [i, j].colors = CB;
				} else {
					ColorBlock CB = buttons [i, j].colors;
					CB.normalColor = new Color (0.913f, 0.913f, 0.0f, 1.0f);
					buttons [i, j].colors = CB;
				}
				if (visit [i, j] == 1) {
					buttons [i, j].interactable = false;
				} else {
					buttons [i, j].interactable = true;
				}
			}
		}
	}
	int distance(int x, int y){
		return Mathf.Abs (x - lastX) + Mathf.Abs (y - lastY);
	}
	protected override void Interaction () {
		// TODO
	}
}
