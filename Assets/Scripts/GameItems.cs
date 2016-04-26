using UnityEngine;
using System.Collections;

public abstract class GameItems : MonoBehaviour {
	public bool interactable;
	public bool collectable;
	public bool zoomable;
	public bool visible;

	protected bool postProcessFlag = false;

	public Vector3 zoomCameraLocation;

	public float distanceThreshold;

	public
	void ClickInteraction () {
		if (interactable) {
			Interaction ();
			if (postProcessFlag) {
				PostProcess ();
			}
		}
	}

	protected abstract void Interaction ();
	protected abstract void PostProcess ();
}
