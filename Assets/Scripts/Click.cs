using UnityEngine;
using System.Collections;

public class Click : MonoBehaviour {

	private Ray ray;
	private RaycastHit hit;

	void Update(){
		if(Input.GetMouseButtonDown(0)){
			ray = Camera.main.ScreenPointToRay(Input.mousePosition);

			if(Physics.Raycast(ray, out hit, Mathf.Infinity)){
				if(hit.transform.gameObject == gameObject){
				}
			}
		}
	}
}
