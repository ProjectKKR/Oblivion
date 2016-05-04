using UnityEngine;
using System.Collections;

public class KeyTrigger: GameItems{

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
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
	public override void ChainOperation (int caseNum){
	}
}
