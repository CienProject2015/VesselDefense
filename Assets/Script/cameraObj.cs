using UnityEngine;
using System.Collections;

public class cameraObj : MonoBehaviour {
	public GameObject myVessel;
	public GameObject vesselCamera;
	public GameObject cameraInit;

	private float cameraSpeed;

	// Use this for initialization
	void Start () {
		cameraSpeed = 2.0f;

	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetMouseButton (1)) {
			float mouseX = Input.GetAxis ("Mouse X");
			float mouseY = Input.GetAxis ("Mouse Y");
			
			transform.Rotate(new Vector3(0,1,0), mouseX*cameraSpeed);

			if(Quaternion.Angle(vesselCamera.transform.rotation,cameraInit.transform.rotation) < 10.0f)
				vesselCamera.transform.Rotate(new Vector3(1,0,0), -mouseY);
			else
				vesselCamera.transform.rotation = Quaternion.Lerp(vesselCamera.transform.rotation, cameraInit.transform.rotation, 0.01f);
	
			Debug.Log (vesselCamera.transform.rotation.x);
		}
		else {
			if(myVessel.rigidbody.angularVelocity != Vector3.zero)
				this.transform.rotation = myVessel.rigidbody.rotation;
			this.transform.rotation = Quaternion.Lerp(this.transform.rotation, myVessel.rigidbody.rotation, 0.1f);
			vesselCamera.transform.rotation = Quaternion.Lerp(vesselCamera.transform.rotation, cameraInit.transform.rotation, 0.05f);
		}


		this.transform.position = myVessel.transform.position;
	}
}
