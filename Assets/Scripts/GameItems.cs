using UnityEngine;
using System.Collections;

public abstract class GameItems : MonoBehaviour {
	public bool interactable;
	public bool collectable;
	public bool zoomable;
	public bool visible;

	protected bool postProcessFlag = false;

	public Vector3 zoomCameraLocation;

	protected float distanceThreshold = 4.0f;
	public float DistanceThreshold {
		get {
			return distanceThreshold;
		}
	}

	public void ClickInteraction (GameItems equipped) {
		if (interactable) {
			if (EquippedItemCheck (equipped)) {
				Interaction ();
			}
			if (postProcessFlag) {
				PostProcess ();
			}
		}
	}

	protected abstract bool EquippedItemCheck (GameItems equipped);
	protected abstract void Interaction ();
	protected abstract void PostProcess ();
}
