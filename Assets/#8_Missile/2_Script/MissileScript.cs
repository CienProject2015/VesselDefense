using UnityEngine;
using System.Collections;

public class MissileScript : MonoBehaviour {

	public float _timer; // time for script runtime
	public float _timerForDel; // time for destroying object
	private bool _raderCollChk; // collision check from the rader

	// Use this for initialization
	void Start () {
	
		GetComponent<Rigidbody>().isKinematic = false;
		GetComponent<Rigidbody>().useGravity = false;

	}
	
	// Update is called once per frame
	void Update () {

			if (_timer > _timerForDel) {

				Destroy(gameObject);
			}
			else
			{
				_timer += Time.deltaTime;
			    _raderCollChk = transform.Find("Rader").gameObject.GetComponent<MissileRader>()._collChk;
			    if(_raderCollChk == false) {

		    		GetComponent<Rigidbody>().AddForce(transform.up * 10.0f);
					// magnitude is a temporary value
					// this can change the velocity before collision, it works together with MissileRader

			    }
			    else {

					GetComponent<Rigidbody>().velocity = new Vector3(0,0,0);

			    }
			}
	}
		
	void OnTriggerEnter(Collider other) {
		if(other.transform.tag == "Enemy") { 

			Destroy(gameObject);

	    }
	}

}
