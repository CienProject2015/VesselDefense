using UnityEngine;
using System.Collections;

public class LaboratoryScene : MonoBehaviour {

	public string fdsa = "     ";

	void Start () {
		
	}
	
	void Update () {
		
	}
	
	void GoTest(){
		Debug.Log("test");
	}
	
	void GoBack(){
		Application.LoadLevel("StationScene");
	}
	
	void OnGUI(){
		GUI.TextField(new Rect(200,100, 100, 100), fdsa, 200);
		
	}
	
}
