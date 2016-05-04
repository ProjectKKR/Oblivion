using UnityEngine;
using System.Collections;

public abstract class GameItems : MonoBehaviour {
	public bool interactable;
	public bool collectable;
	public bool zoomable;
	public bool visible;

	protected bool postProcessFlag = false;

	private Vector3 zoomLocation;
	private Quaternion zoomRotation;

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
		}
	}

	public void zoomIn(){
		
	}

	public void setLocation(Vector3 pos){
		zoomLocation = pos;
	}
	public void setRotation(Quaternion rot){
		zoomRotation = rot;
	}

	public Vector3 getLocation(){
		return zoomLocation;
	}

	public Quaternion getRotation(){
		return zoomRotation;
	}

	protected abstract bool EquippedItemCheck (GameItems equipped);
	public abstract void ChainOperation (int caseNum);
	protected abstract void Interaction ();
	protected abstract void PostProcess ();
}
