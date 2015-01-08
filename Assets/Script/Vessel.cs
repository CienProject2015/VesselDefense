using UnityEngine;
using System.Collections;
//using System.Timers;

public class Vessel: MonoBehaviour {
	private float forceX, forceZ;
	private float torqueY;

	public GameObject vesselCamera;
	public GameObject cameraObj;
	public int HP;

	//private Timer timer;
	// Use this for initialization
	void Start () {
		this.rigidbody.mass = 10;
		this.forceX = 15.0f;
		this.forceZ = 15.0f;

		this.torqueY = 1.0f;
		//this.timer = new Timer ();	
	}
	
	// Update is called once per frame
	void Update () {

		if (Input.GetKey (KeyCode.W)) {
			this.rigidbody.AddForce(this.transform.forward * this.forceX);
		} else if (Input.GetKey (KeyCode.S)) {
			this.rigidbody.AddForce(-this.transform.forward * this.forceX); 
		}
		if (Mathf.Abs(this.rigidbody.velocity.x) < 0.04) {
			Vector3 temp = this.rigidbody.velocity;
			temp.x = 0.0f;
			this.rigidbody.velocity = temp;
		}

		if (Input.GetKey (KeyCode.A)) {
			this.rigidbody.AddForce(-this.transform.right * this.forceZ);
		} else if (Input.GetKey (KeyCode.D)) {
			this.rigidbody.AddForce(this.transform.right * this.forceZ);
		}
		if (Mathf.Abs(this.rigidbody.velocity.z) < 0.04) {
			Vector3 temp = this.rigidbody.velocity;
			temp.z = 0.0f;
			this.rigidbody.velocity = temp;
		}

		if(Input.GetKey(KeyCode.Q)) 
			this.rigidbody.AddTorque(new Vector3(0,-torqueY,0));
		if(Input.GetKey(KeyCode.E)) 
			this.rigidbody.AddTorque(new Vector3(0,torqueY,0));

		if(!Input.GetKey(KeyCode.Q) && !Input.GetKey(KeyCode.E)){
			if(this.rigidbody.angularVelocity.y < -0.5f)
				this.rigidbody.AddTorque(new Vector3(0,torqueY,0));
			else if(this.rigidbody.angularVelocity.y > 0.5f)
				this.rigidbody.AddTorque(new Vector3(0,-torqueY,0));
			else
				this.rigidbody.angularVelocity = Vector3.Lerp(this.rigidbody.angularVelocity, Vector3.zero, 0.1f);
		}




	}
	public void Damage(int dam){
		this.HP -= dam;
	}



}
