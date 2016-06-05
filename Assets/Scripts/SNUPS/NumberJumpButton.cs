using UnityEngine;
using System.Collections;

public class NumberJumpButton : MonoBehaviour {
	private NumberJump nj;
	public int number;
	void Start(){
		nj = transform.parent.parent.GetComponent<NumberJump>();
		if (nj==null) nj = transform.parent.GetComponent<NumberJump>();
	}
	public void PressButton(){
		nj.PressButton (number);
	}
	public void ResetButton(){
		nj.PressReset();
	}
}
