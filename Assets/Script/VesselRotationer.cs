using UnityEngine;
using System.Collections;

public class VesselRotationer : MonoBehaviour {
	public GameObject vesselCamera;
	public GameObject myVessel;
	public Quaternion targetQuaternion;
	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {


		SetVesselDirection ();
	}

	private void SetPosition(){
		this.transform.position = this.myVessel.rigidbody.position;
		
	}

	private void SetVesselDirection()
	{
		// マウスポインタの方向に向く角度を求める.
		Vector3 mousePos = GetWorldPotitionFromMouse();
		Vector3 relativeMousePos = mousePos - transform.position;
		//Vector3 relativeVesselPos = mousePos - transform.position;
		Quaternion targetRotation = Quaternion.LookRotation( relativeMousePos );
		//Quaternion preRotation = Quaternion.LookRotation( relativeVesselPos );
		this.transform.rotation = targetRotation;
		//Vector3.Angle (relativeMousePos, relativeVesselPos);
		// プレイヤーの角度を変更
		
		this.myVessel.SendMessage ("SetVesselDirection", targetRotation);

	}
	

	private Vector3	GetWorldPotitionFromMouse()
	{
		Vector3	mousePosition = Input.mousePosition;
		
		// ピースの中心を通る、水平（法線がY軸。XZ平面）な面.
		// 中心はプレイヤーとする.
		Plane plane = new Plane( Vector3.up, new Vector3( 0f, 0f, 0f ) );
		
		// カメラ位置とマウスカーソルの位置を通る直線.
		Ray ray = vesselCamera.GetComponent<Camera>().ScreenPointToRay( mousePosition );
		
		// 上の二つが交わるところを求める.
		float depth;
		
		plane.Raycast( ray, out depth );
		
		Vector3	worldPosition;
		
		worldPosition = ray.origin + ray.direction * depth;
		
		// Y座標はプレイヤーとあわせておく.
		worldPosition.y = 0;
		
		return worldPosition;
	}
}
