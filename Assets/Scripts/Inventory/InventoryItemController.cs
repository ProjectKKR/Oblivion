using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

public class InventoryItemController : MonoBehaviour {
	public GameObject content;
	public int maxItem = 5;
	public GameObject highlightFrame;

	private List<GameItems> itemList = new List<GameItems>();
	private GameObject[] PreviewList = new GameObject[10];
	private int equipIndex; // 몇번째 아이템을 장착중인가

	void Start(){
		highlightFrame.SetActive (false);
		for (int i = 0; i < maxItem; i++) {
			PreviewList [i] = content.transform.GetChild (i).gameObject;
		}
		equipIndex = -1; // DEFAULT
	}
	public void Add(GameItems item){
		itemList.Add (item);
		Refresh ();
		if (itemList.Count > maxItem) print ("Inventory Exceed");
	}

	public void Delete(GameItems item){
		for (int i=0;i<itemList.Count;i++){
			if (itemList[i].Equals(item)){
				if (equipIndex > i)
					equipIndex--;
				else if (equipIndex == i)
					equipIndex = -1;
				itemList.RemoveAt(i);
				break;
			}
		}
		Refresh ();
	}
						

	public void Clicked(int number){
		if (number >= itemList.Count)
			return;
		if (equipIndex == number) {
			equipIndex = -1;
		} else {
			equipIndex = number;
		}
		Refresh ();
	}

	private void Refresh(){
		/* highlightFrame */
		if (equipIndex != -1 && equipIndex < itemList.Count) {
			highlightFrame.SetActive (true);
			highlightFrame.transform.position = PreviewList [equipIndex].transform.position;
		}
		else highlightFrame.SetActive(false);

		/* visualize preview image */
		if (itemList.Count > maxItem) print ("Inventory Exceed");
		for (int i = 0; i < maxItem; i++) {
			//GameObject redFrame = Content.transform.GetChild (i).GetChild(0).gameObject;
			//redFrame.SetActive (itemRoom.equipFlag & itemRoom.itemExistFlag);
			if (i>=itemList.Count){
				// 빈 공간
				PreviewList [i].GetComponent<RawImage> ().texture = null;
			}else{
				PreviewList [i].GetComponent<RawImage> ().texture = itemList [i].preview;
			}
		}
	}

	public GameItems CurrentItem(){
		if (equipIndex == -1 || equipIndex >= itemList.Count)
			return null;
		return itemList [equipIndex];
	}
}