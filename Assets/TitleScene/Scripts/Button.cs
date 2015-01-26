using UnityEngine;
using System.Collections;

public class Button : MonoBehaviour{
	public int PixelX = 0;
	public int PixelY = 0;
	public int width = 0;
	public int height = 0;
	
	public string SendFuncName = "GoNext";
	public GameObject SendFuncObject;
	
	private float inx;
	private float iny;
	private float vx;
	private float vy;
	private float ScreenW;
	private float ScreenH;
	private bool buttonDown = false;
	
	public Texture ButtonUp;
	public Texture ButtonDown;
	
	void Start () {
		ScreenW = Camera.mainCamera.GetScreenWidth();
		ScreenH = Camera.mainCamera.GetScreenHeight();
		vx = ScreenW * transform.localScale.x;
		vy = ScreenH * transform.localScale.y;
		inx = ScreenW * transform.position.x + PixelX - vx/2;
		iny = ScreenH * (1-transform.position.y) - PixelY - height - vy/2;
		vx += width;
		vy += height;

	}
	
	void Update () {
		if(Input.GetMouseButton(0)){
			float inputX = Input.mousePosition.x;
			float inputY = ScreenH - Input.mousePosition.y;
			if(inx < inputX && inputX < inx + vx){
				if(iny < inputY && inputY < iny + vy){
					buttonDown = true;

				}
			}
		}else{
			if(buttonDown){
				buttonDown = false;
				if(SendFuncObject){
					Click();
				}
			}
		}
	}
	
	void SetSendGameObject(GameObject obj){
		SendFuncObject = obj;
	}
	
	void SetSendFuncName(string st){
		SendFuncName = st;
	}
	
	void Click(){
		SendFuncObject.SendMessage(SendFuncName);
	}
	
	void OnGUI(){
		if(buttonDown){
			GUI.DrawTexture(new Rect(inx, iny, vx, vy), ButtonDown);
		}else{
			GUI.DrawTexture(new Rect(inx, iny, vx, vy), ButtonUp);
		}
	}
	

}
