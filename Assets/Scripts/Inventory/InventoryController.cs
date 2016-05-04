using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using System.Collections;


public class InventoryController : MonoBehaviour, IPointerDownHandler {
	private RawImage invPoint;
	private int scale = 6;
	private int time = 0;
	private bool opened = false;

	float intervalStart, intervalEnd;

	void Start () {
		invPoint = transform.GetChild (0).GetComponent<RawImage> ();
		intervalStart = 20.0f - 250.0f;
		intervalEnd = 140.0f - 250.0f;
		transform.localPosition = new Vector3 (0, intervalStart, 0);
	}

	void Update () {
		if (opened && time <= 20) {
			transform.localPosition = new Vector3 (0, (time/20.0f) * (intervalEnd-intervalStart) + intervalStart, 0);
			invPoint.transform.eulerAngles = new Vector3 (0, 0, time / 20.0f * 180);
			if (time<20) time++;
		} else if ((!opened) && time >= 0) {
			transform.localPosition = new Vector3 (0, (time/20.0f) * (intervalEnd-intervalStart) + intervalStart, 0);
			invPoint.transform.eulerAngles = new Vector3 (0, 0, time / 20.0f * 180);
			if (time>0) time--;
		}
	}

	public virtual void OnPointerDown(PointerEventData ped){
		opened = !opened;
	}
}
