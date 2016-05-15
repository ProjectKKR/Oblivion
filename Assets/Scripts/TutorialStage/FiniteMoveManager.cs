using UnityEngine;
using System.Collections;

public abstract class FiniteMoveManager : MonoBehaviour {
	public const float W = 57.325f;
	public abstract void MoveUnit(GameObject unit,int direction);
	protected abstract void Refresh ();
	protected abstract void CheckAnswer ();
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