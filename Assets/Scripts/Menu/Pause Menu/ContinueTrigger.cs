using UnityEngine;
using System.Collections;

public class ContinueTrigger : MonoBehaviour {
	public GameObject PauseMenu;
	public void Trigger(){
		PauseMenu.SetActive (false);
	}
}
