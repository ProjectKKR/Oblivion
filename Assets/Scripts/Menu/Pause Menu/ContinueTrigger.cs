using UnityEngine;
using System.Collections;

public class ContinueTrigger : MonoBehaviour {
	public GameObject PauseMenu;
	// Use this for initialization
	public void Trigger(){
		PauseMenu.SetActive (false);
	}
}
