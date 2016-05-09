using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using System.Collections;


public class InventoryController : MonoBehaviour, IPointerClickHandler {
	public GameObject invPlane;
	private RawImage invPoint;
	private int time = 0;
	private bool opened = false;

	float intervalStart, intervalEnd;
	float intervalStart2, intervalEnd2;

	void Start () {
		invPoint = transform.GetChild (0).GetComponent<RawImage> ();
		intervalStart = 20.0f - 250.0f;
		intervalEnd = 140.0f - 250.0f;
		intervalStart2 = -60.0f - 250.0f;
		intervalEnd2 = 60.0f - 250.0f;
		transform.localPosition = new Vector3 (0, intervalStart, 0);
		invPlane.transform.localPosition = new Vector3 (0, intervalStart2, 0);

	}

	void Update () {
		if (opened && time <= 20) {
			transform.localPosition = new Vector3 (0, (time/20.0f) * (intervalEnd-intervalStart) + intervalStart, 0);
			invPlane.transform.localPosition = new Vector3 (0, (time/20.0f) * (intervalEnd2-intervalStart2) + intervalStart2, 0);
			invPoint.transform.eulerAngles = new Vector3 (0, 0, time / 20.0f * 180);
			if (time<20) time++;
		} else if ((!opened) && time >= 0) {
			transform.localPosition = new Vector3 (0, (time/20.0f) * (intervalEnd-intervalStart) + intervalStart, 0);
			invPlane.transform.localPosition = new Vector3 (0, (time/20.0f) * (intervalEnd2-intervalStart2) + intervalStart2, 0);
			invPoint.transform.eulerAngles = new Vector3 (0, 0, time / 20.0f * 180);
			if (time>0) time--;
		}
	}

	public virtual void OnPointerClick(PointerEventData ped){
		opened = !opened;
	}
}
