using UnityEngine;
using System.Collections;

public class Inventory : MonoBehaviour {

	public int selectItem = 0;
	private float itemPos = 0;

	void Start () {
	
	}

	void Update () {
		ShowItem();
	}

	void ShowItem(){
		itemPos += (selectItem - itemPos)*0.2f;
		for(int i = 0; i<transform.childCount ; i++){
			transform.GetChild(i).localPosition = new Vector3(0,2*(-i + itemPos),0);
		}
	}

	void UpItem(){
		selectItem++;
		if(transform.childCount-1<selectItem){
			selectItem = transform.childCount-1;
		}
	}

	void DownItem(){
		selectItem--;
		if(selectItem<0){
			selectItem = 0;
		}
	}
}
