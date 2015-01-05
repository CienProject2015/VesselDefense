using UnityEngine;
using System.Collections;


public class VesselCamera : MonoBehaviour {
	private float positionX;
	private float positionZ;
	private Vector3 cameraPosition;
	private Vector3 cameraVelocity;
	public GameObject myVessel;
	// Use this for initialization
	void Start () {
		this.cameraPosition = new Vector3 (0, 10, -5);
		this.cameraVelocity = new Vector3 (0, 0, 0);
	}
	
	// Update is called once per frame
	void Update () {
		SetPosition ();
	}

	void SetPosition(){
		this.cameraPosition = this.myVessel.rigidbody.position;
		this.cameraPosition.y += 10.0f;
		this.cameraPosition.z -= 5.0f;
		this.rigidbody.position = this.cameraPosition;
	}

	void SetVelocity(Vector3 vel){
		this.rigidbody.velocity = this.myVessel.rigidbody.velocity;
	}

}
