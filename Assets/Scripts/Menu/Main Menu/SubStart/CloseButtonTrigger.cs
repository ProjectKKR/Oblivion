using UnityEngine;
using System.Collections;

public class CloseButtonTrigger : MonoBehaviour {
	public GameObject subMenu;
	public void Trigger(){
		subMenu.SetActive(false);
	}
}
