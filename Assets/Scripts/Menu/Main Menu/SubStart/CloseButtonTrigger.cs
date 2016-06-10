using UnityEngine;
using System.Collections;

public class CloseButtonTrigger : MonoBehaviour {
	public GameObject subMenu;
	public void Trigger(){
		//TODO : Delete all save data
		subMenu.SetActive(false);
	}
}
