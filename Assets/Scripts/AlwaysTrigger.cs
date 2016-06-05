using UnityEngine;
using System.Collections;

public class AlwaysTrigger : MonoBehaviour {
	public GameObject PauseMenu;
	public PlayerController player;
	// Use this for initialization
	void Start () {
		PauseMenu.SetActive (false);	
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown(KeyCode.Escape))
		{
			if (player.zooming == false && !player.getZoomFlag())
				PauseMenu.SetActive (!PauseMenu.activeInHierarchy);
			else if (player.getZoomFlag())
				player.ZoomOut ();
		}
	}
}