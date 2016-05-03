using UnityEngine;
using System.Collections;

public class AlwaysTrigger : MonoBehaviour {
	public GameObject PauseMenu;

	// Use this for initialization
	void Start () {
		PauseMenu.SetActive (false);	
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown(KeyCode.Escape))
		{
			PauseMenu.SetActive (!PauseMenu.activeInHierarchy);
		}
	}
}
