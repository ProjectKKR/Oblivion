using UnityEngine;
using System.Collections;

public class Door :  GameItems {
	public float speed;
	public GameObject axis;

	private AudioSource openAudio;
	private AudioSource closeAudio;
	private Ray ray;
	private RaycastHit hit;
	private float openFlag=1.0f;

	void Start () {
		AudioSource[] sounds = GetComponents<AudioSource> ();
		openAudio = sounds[0];
		closeAudio = sounds[1];
	}

	protected override void Interaction () {
		axis.transform.Rotate (new Vector3 (0, -80.0f * openFlag, 0));
		openFlag = - openFlag;
		if (openFlag == 1.0f) {
			openAudio.Play ();
		}
		else {
			closeAudio.Play ();
		}
	}
}