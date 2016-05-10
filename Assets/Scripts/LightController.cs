using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class LightController : MonoBehaviour {
	private List<float> initialIntensity;
	// Use this for initialization
	void Start () {
		initialIntensity = new List<float> ();
		for (int i = 0; i < transform.childCount; i++) {
			Light l = this.gameObject.transform.GetChild (i).GetComponent<Light> ();
			initialIntensity.Add(l.intensity);
		}
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void Light (bool state) {
		for (int i = 0; i < transform.childCount; i++) {
			Light l = this.gameObject.transform.GetChild (i).GetComponent<Light> ();
			l.intensity = state ? initialIntensity[i] : 0.1f;
		}
	}
}
