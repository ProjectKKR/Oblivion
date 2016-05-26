using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using System.Collections;

public class DragView : MonoBehaviour, IDragHandler, IPointerDownHandler, IPointerUpHandler {
	private Image dragPanel;
	private Vector2 noTouch = new Vector2(-1000, -1000);
	private Vector2 inputVector;
	// Use this for initialization
	void Start () {
		dragPanel = GetComponent<Image> ();
		inputVector = noTouch;
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public virtual void OnDrag(PointerEventData ped) {
		Vector2 pos;
		if (RectTransformUtility.ScreenPointToLocalPointInRectangle (dragPanel.rectTransform,
																	ped.position,
																	ped.pressEventCamera,
																	out pos)) {
			inputVector = pos;
		}
	}

	public virtual void OnPointerDown(PointerEventData ped) {
		OnDrag (ped);
	}

	public virtual void OnPointerUp(PointerEventData ped) {
		inputVector = noTouch;
	}

	public Vector2 GetInputVector() {
		return inputVector;
	}

	public bool isTouched() {
		return (inputVector.x != -1000 || inputVector.y != -1000);
	}
}
