using UnityEngine;
using System.Collections;

public class AlwaysTrigger : MonoBehaviour {
	public GameObject PauseMenu;
	public PlayerController player;
	void Start () {
		PauseMenu.SetActive (false);	
	}
	void Update () {
		if (Input.GetKeyDown(KeyCode.Escape))
		{
			if (player.zooming == false && !player.getZoomFlag ())
				PauseMenu.SetActive (!PauseMenu.activeInHierarchy);
			else if (player.getZoomFlag ())
				player.ZoomOut ();
		}
	}
}