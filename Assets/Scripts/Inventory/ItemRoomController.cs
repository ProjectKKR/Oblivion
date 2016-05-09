using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using System.Collections;

public class ItemRoomController : MonoBehaviour, IPointerClickHandler {
	public InventoryItemController iic;
	public int number;
	public virtual void OnPointerClick(PointerEventData ped){
		print ("click");
		iic.Clicked (number);
	}
	public void ShowImage(Texture texture){
		transform.GetComponent<RawImage> ().texture = texture;
	}
	public void DeleteImage(){
		transform.GetComponent<RawImage> ().texture = null;
	}
}