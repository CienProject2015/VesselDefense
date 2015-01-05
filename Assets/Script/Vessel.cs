using UnityEngine;
using System.Collections;
//using System.Timers;

public class Vessel: MonoBehaviour {
	private float velocityX, velocityZ;
	private Vector3 vesselPosition;
	private Vector3 vesselVelocity;
	private Quaternion vesselQuaternion;
	private Quaternion targetQuaternion;

	public GameObject vesselCamera;
	public GameObject vesselRotationer;
	public int HP;
	public Material vesselMaterial;

	//private Timer timer;
	// Use this for initialization
	void Start () {
		this.velocityX = 0.05f;
		this.velocityZ = 0.05f;

		this.vesselPosition.x = this.rigidbody.position.x;
		this.vesselPosition.z = this.rigidbody.position.z;
		this.vesselVelocity = this.rigidbody.velocity;
		this.vesselPosition.y = 0.0f;
		//this.timer = new Timer ();
	}
	
	// Update is called once per frame
	void Update () {

		if (Input.GetKey (KeyCode.W)) {
			this.rigidbody.velocity += this.rigidbody.transform.forward * this.velocityX;
		} else if (Input.GetKey (KeyCode.S)) {
			this.rigidbody.velocity += this.rigidbody.transform.forward * this.velocityX * -1.0f; 
		}
		if (Mathf.Abs(this.rigidbody.velocity.x) < 0.04) {
			Vector3 temp = this.rigidbody.velocity;
			temp.x = 0.0f;
			this.rigidbody.velocity = temp;
		}

		if (Input.GetKey (KeyCode.A)) {
			this.rigidbody.velocity += this.rigidbody.transform.right * this.velocityZ * -1.0f;
		} else if (Input.GetKey (KeyCode.D)) {
			this.rigidbody.velocity += this.rigidbody.transform.right * this.velocityZ;
		}
		if (Mathf.Abs(this.rigidbody.velocity.z) < 0.04) {
			Vector3 temp = this.rigidbody.velocity;
			temp.z = 0.0f;
			this.rigidbody.velocity = temp;
		}

		rotateVessel ();
	}
	public void Damage(int dam){
		this.HP -= dam;
	}

	private void SetPlayerDirection()
	{


	}

	private void SetVesselDirection(Quaternion target){

		this.vesselQuaternion = this.transform.rotation;
		this.targetQuaternion = target;

	}

	void rotateVessel(){
		Quaternion tempQuaternion = Quaternion.Lerp (this.vesselQuaternion, this.targetQuaternion, 0.02f);
		this.rigidbody.rotation = tempQuaternion;
	}

}
