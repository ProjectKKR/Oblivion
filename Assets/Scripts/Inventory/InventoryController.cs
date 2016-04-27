using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using System.Collections;


public class InventoryController : MonoBehaviour, IPointerDownHandler {
	private RawImage invPoint;
	public GameObject invPlane;
	private int scale = 6;
	private int time = 0;
	private bool opened = false;

	void Start () {
		invPoint = transform.GetChild (0).GetComponent<RawImage> ();
	}

	void Update () {
		if (opened && time <= 20) {
			transform.localPosition = new Vector3 (0, time*scale - 205, 0);
			invPoint.transform.eulerAngles = new Vector3 (0, 0, time / 20.0f * 180);
			invPlane.transform.localPosition = new Vector3 (0, time*scale - 285, 0);
			time++;
		} else if ((!opened) && time >= 0) {
			transform.localPosition = new Vector3 (0, time*scale - 205, 0);
			invPoint.transform.eulerAngles = new Vector3 (0, 0, time / 20.0f * 180);
			invPlane.transform.localPosition = new Vector3 (0, time*scale - 285, 0);
			time--;
		}
	}

	public virtual void OnPointerDown(PointerEventData ped){
		opened = !opened;
	}
}
