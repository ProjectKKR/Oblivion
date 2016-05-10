using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public abstract class GameItems : MonoBehaviour {
	public bool interactable;
	public bool collectable;
	public bool zoomable;
	public bool visible;
	public Texture preview;

	protected bool postProcessFlag = false;
	protected Vector3 zoomLocation;
	protected Quaternion zoomRotation;
	protected float distanceThreshold = 4.0f;

	public Quaternion ZoomRotation {
		get { return zoomRotation; }
	}
	public Vector3 ZoomLocation {
		get { return zoomLocation; }
	}
	public float DistanceThreshold {
		get { return distanceThreshold; }
	}
	public void ClickInteraction (GameItems equipped) {
		if (interactable)
			if (EquippedItemCheck (equipped))
				Interaction ();
	}
	protected virtual bool EquippedItemCheck (GameItems equipped){
		return true;
	}
	public void ChainOperation (int caseNum){}
	protected void PostProcess (){}
	protected abstract void Interaction ();
}
