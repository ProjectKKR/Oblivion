using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using System.Collections;

public class VirtualJoystick_left : MonoBehaviour, IDragHandler, IPointerUpHandler, IPointerDownHandler {

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
			pos.y = (pos.y / bgImg.rectTransform.sizeDelta.y);
			inputVector = new Vector3 (pos.x * 2, 0, pos.y * 2);
			inputVector = (inputVector.magnitude > 1.0f) ? inputVector.normalized : inputVector;

			// Move Joystick Image
			jsImg.rectTransform.anchoredPosition = 
				new Vector3 (inputVector.x * (bgImg.rectTransform.sizeDelta.x / 3)
					, inputVector.z * (bgImg.rectTransform.sizeDelta.y / 3));
		}
	}
	public virtual void OnPointerDown(PointerEventData ped){
		OnDrag (ped);
	}
	public virtual void OnPointerUp(PointerEventData ped){
		inputVector = Vector3.zero;
		jsImg.rectTransform.anchoredPosition = Vector3.zero;
	}
	public float Horizontal(){
		if (inputVector.x != 0)
			return inputVector.x;
		else
			return Input.GetAxis ("Horizontal");
	}
	public float Vertical(){
		if (inputVector.z != 0)
			return inputVector.z;
		else
			return Input.GetAxis ("Vertical");
	}
}