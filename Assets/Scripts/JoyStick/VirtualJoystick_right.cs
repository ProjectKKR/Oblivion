using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using System.Collections;

public class VirtualJoystick_right: MonoBehaviour, IDragHandler, IPointerUpHandler, IPointerDownHandler {

	private Image bgImg;
	private Image jsImg; // JoystickImg
	private Vector3 inputVector;
	private void Start(){
		bgImg = GetComponent<Image> ();
		jsImg = transform.GetChild (0).GetComponent<Image> ();
	}
	public virtual void OnDrag(PointerEventData ped){
		Vector2 pos;
		if (RectTransformUtility.ScreenPointToLocalPointInRectangle (bgImg.rectTransform,
																	 ped.position,
																	 ped.pressEventCamera,
																	 out pos)) {
			pos.x = (pos.x / bgImg.rectTransform.sizeDelta.x);
			pos.y = 0;
			inputVector = new Vector3 (pos.x * 2, 0, 0);
			inputVector = (inputVector.magnitude > 1.0f) ? inputVector.normalized : inputVector;

			// Move Joystick Image
			jsImg.rectTransform.anchoredPosition = 
				new Vector3 (inputVector.x * (bgImg.rectTransform.sizeDelta.x / 3)
					, 0);
		} 
	}
	public virtual void OnPointerDown(PointerEventData ped){
		OnDrag (ped);
	}
	public virtual void OnPointerUp(PointerEventData ped){
		inputVector = Vector3.zero;
		jsImg.rectTransform.anchoredPosition = Vector3.zero;
	}
	public float Turn(){
		return inputVector.x;
	}
}