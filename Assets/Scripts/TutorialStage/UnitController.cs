using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using System.Collections;

public class UnitController : MonoBehaviour, IPointerDownHandler, IPointerUpHandler {
	public FiniteMoveManager manager;
	const float W = 57.325f;
	private Vector2 position, com_position;
	void Start(){
		position = com_position = Vector2.zero;
	}
	public virtual void OnPointerDown(PointerEventData ped){
		position = Input.mousePosition;
	}
	public virtual void OnPointerUp(PointerEventData ped){
		com_position = Input.mousePosition;
		if ((position - com_position).magnitude > 30) {
			float dif_x = com_position.x - position.x;
			float dif_y = com_position.y - position.y;
			if (Mathf.Abs (dif_x) > Mathf.Abs (dif_y)) {
				if (dif_x > 0)
					manager.MoveUnit (this.gameObject, 0);
				if (dif_x < 0)
					manager.MoveUnit (this.gameObject, 2);
			} else {
				if (dif_y > 0)
					manager.MoveUnit (this.gameObject, 3);
				if (dif_y < 0)
					manager.MoveUnit (this.gameObject, 1);
			}
		}
	}
}
