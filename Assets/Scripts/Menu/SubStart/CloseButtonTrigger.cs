using UnityEngine;
using System.Collections;

public class CloseButtonTrigger : MonoBehaviour {
	public GameObject SubStart;
	public void Trigger(){
		//TODO : Delete all save data
		SubStart.SetActive(false);
	}
}
