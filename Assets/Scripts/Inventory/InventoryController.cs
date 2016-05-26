using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using System.Collections;


public class InventoryController : MonoBehaviour, IPointerClickHandler {
	public GameObject invPlane;
	private RawImage invPoint;
	private int time = 0;
	private bool opened = false;
	private float animationStep = 20.0f;

	public GameObject inventoryCanvas;
	float intervalStart, intervalEnd;
	float intervalStart2, intervalEnd2;

	void Start () {
		invPoint = transform.GetChild (0).GetComponent<RawImage> ();
		float buttonHeight = transform.GetComponent<RectTransform> ().rect.height;
		float planeHeight = invPlane.transform.GetComponent<RectTransform> ().rect.height;
		float canvasHeight = inventoryCanvas.transform.GetComponent<RectTransform> ().rect.height;
		intervalStart = buttonHeight / 2 - canvasHeight / 2;
		intervalEnd = planeHeight + buttonHeight / 2 - canvasHeight / 2;
		intervalStart2 = -planeHeight / 2 - canvasHeight / 2;
		intervalEnd2 = planeHeight / 2 - canvasHeight / 2;
		transform.localPosition = new Vector3 (0, intervalStart, 0);
		invPlane.transform.localPosition = new Vector3 (0, intervalStart2, 0);

	}

	void Update () {
		if (opened && time <= animationStep) {
			transform.localPosition = new Vector3 (0, (time/animationStep) * (intervalEnd-intervalStart) + intervalStart, 0);
			invPlane.transform.localPosition = new Vector3 (0, (time/animationStep) * (intervalEnd2-intervalStart2) + intervalStart2, 0);
			invPoint.transform.eulerAngles = new Vector3 (0, 0, time / animationStep * 180);
			if (time<animationStep) time++;
		} else if ((!opened) && time >= 0) {
			transform.localPosition = new Vector3 (0, (time/animationStep) * (intervalEnd-intervalStart) + intervalStart, 0);
			invPlane.transform.localPosition = new Vector3 (0, (time/animationStep) * (intervalEnd2-intervalStart2) + intervalStart2, 0);
			invPoint.transform.eulerAngles = new Vector3 (0, 0, time / animationStep * 180);
			if (time>0) time--;
		}
	}

	public virtual void OnPointerClick(PointerEventData ped){
		opened = !opened;
	}
}
