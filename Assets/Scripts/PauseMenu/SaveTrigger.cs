using UnityEngine;
using System.Collections;

public class SaveTrigger : MonoBehaviour {

	public GameObject player;

	public void Trigger(){
		// TODO : Overlap save data
		PlayerPrefsX.SetVector3 ("playerPosition", player.transform.position);
		PlayerPrefsX.SetQuaternion ("playerRotation", player.transform.rotation);
	}
}
