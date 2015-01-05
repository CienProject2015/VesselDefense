using UnityEngine;
using System.Collections;
//using System.Timers;

public class Vessel: MonoBehaviour {
	private float velocityX, velocityZ;
	private Vector3 vesselPosition;
	private Vector3 vesselVelocity;
	private Vector3 vectorX = new Vector3(1,0,0);
	private Vector3 vectorY = new Vector3(0,1,0);
	private Vector3 vectorZ = new Vector3(0,0,1);
	private Vector3 preMousePos;
	Vector3 mousePosition;
	float rotateAngle;

	public GameObject vesselCamera;
	public int HP;
	public Material vesselMaterial;
	//private Timer timer;
	// Use this for initialization
	void Start () {
		this.velocityX = 0.05f;
		this.velocityZ = 0.05f;
		this.mousePosition = Input.mousePosition;
		preMousePos = this.GetWorldPotitionFromMouse ();

		this.vesselPosition.x = this.rigidbody.position.x;
		this.vesselPosition.z = this.rigidbody.position.z;
		this.vesselVelocity = this.rigidbody.velocity;
		this.vesselPosition.y = 0.0f;
		//this.timer = new Timer ();
	}
	
	// Update is called once per frame
	void Update () {

		if (Input.GetKey (KeyCode.W)) {
			this.rigidbody.velocity += Vector3.forward * this.velocityX;
		} else if (Input.GetKey (KeyCode.S)) {
			this.rigidbody.velocity += Vector3.back * this.velocityX; 
		}
		if (Mathf.Abs(this.rigidbody.velocity.x) < 0.05) {
			Vector3 temp = this.rigidbody.velocity;
			temp.x = 0.0f;
			this.rigidbody.velocity = temp;
		}

		if (Input.GetKey (KeyCode.A)) {
			this.rigidbody.velocity += Vector3.left * this.velocityZ;
		} else if (Input.GetKey (KeyCode.D)) {
			this.rigidbody.velocity += Vector3.right * this.velocityZ; 
		}
		if (Mathf.Abs(this.rigidbody.velocity.z) < 0.05) {
			Vector3 temp = this.rigidbody.velocity;
			temp.z = 0.0f;
			this.rigidbody.velocity = temp;
		}

		/*
		this.rotateAngle = Input.mousePosition.x * this.mousePosition.x + Input.mousePosition.z * this.mousePosition.z;

		if(rotateAngle != 0){
			if(rotateAngle<0){
			}

			else if(rotateAngle>0){
			}
		}*/



		//this.vesselPosition.x = this.rigidbody.position.x;
		//this.vesselPosition.z = this.rigidbody.position.z;
		//vesselCamera.SendMessage ("SetPosition",this.vesselPosition);
		//vesselCamera.SendMessage ("SetVelocity",this.rigidbody.velocity);
		//vesselCamera.SendMessage ("SetPosition",this.rigidbody.position);
		SetPlayerDirection ();
	}
	void Damage(int dam){
		this.HP -= dam;
	}

	void OnColisionEnter(Collision collision){
		//vesselCamera.SendMessage ("SetPosition",this.rigidbody.position);
	}


	private void SetPlayerDirection()
	{
		// マウスポインタの方向に向く角度を求める.
		Vector3 mousePos = GetWorldPotitionFromMouse();
		Vector3 relativePos = mousePos - transform.position;
		Quaternion tmpRotation = Quaternion.LookRotation( relativePos );
		this.rigidbody.transform.rotation = tmpRotation;
		// プレイヤーの角度を変更



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
	private Vector3	GetWorldPotitionFromVessel()
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
