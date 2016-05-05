using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

public class InventoryVisualizer : MonoBehaviour {
	public PlayerController Player;
	private List<GameItems> itemList = new List<GameItems>();
	private List<RawImage> itemImageList = new List<RawImage>();
	public int maxItem = 5;

	void Start(){
		itemList = Player.inventory;
		for (int i = 0; i < maxItem; i++) {
			itemImageList.Add(GameObject.Find ("Preview" + i.ToString ()).GetComponent<RawImage> ());
		}
	}
	public void Modify(){
		for (int i = 0; i < itemList.Count; i++) {
			
		}
	}
}
