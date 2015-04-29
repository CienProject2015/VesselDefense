using UnityEngine;
using System.Collections;

public class MissileRader : MonoBehaviour {
	
	public float aim_Angle; // An float number for cheking the angle between a player and an enemy
	public float _timeForColl; // An float number for missile flight time after collision
	public bool _enemyFind; 
	public bool _collChk; // collision check	
	private float _timer; // time for script runtime
	private float _timerForDel; // time for destroying object	
	private Vector3 _disVec; // distance between a missile and an enemy
	private Vector3 _fVec; // sum of all the force after collision
	private Vector3 _v0Vec; // a unit vector to calcutate initial velocity
	private float _A; // a temporary variable  
	private float _B; // a temporary variable
	private float _radius; // a radius of collider
	private float _adj; // a value to adjust velocity as radius		
	private GameObject _enemy;
	private GameObject _missile;
	
	// Use this for initialization
	void Start () {
		
		GetComponent<Rigidbody>().isKinematic = false;
		GetComponent<Rigidbody>().useGravity = false;
		_missile = gameObject.transform.parent.gameObject;
		_timerForDel = _missile.transform.GetComponent<MissileScript>()._timerForDel;
		_radius = GetComponent<SphereCollider>().radius;
		_enemyFind = false;
		_collChk = false;
		_v0Vec = _missile.transform.up; // present position of a missile
		
	}
	
	// Update is called once per frame
	void Update () {

		if (_timer > _timerForDel) {

			Destroy(gameObject);
		}
		else {

			_timer += Time.deltaTime;
			if (_collChk == false) {

				rigidbody.AddForce(transform.up * 10.0f); 
				// magnitude is a temporary value
				// this can change the velocity before collision, it works together with MissileScript
			}
			else {

				rigidbody.velocity = new Vector3(0,0,0);
				if (_enemyFind = true && _enemy != null) {

					rigidbody.AddForce(_fVec * 0.004f);
					_missile.rigidbody.AddForce(_fVec * 0.004f);
					// magnitude is a temporay value, but its operation must be needed careful
					// may be 0.001 ~ 0.005
					// this will change the velocity after collision

				}
			}
		}
	}
	
	void OnTriggerEnter(Collider other) {
		//Debug.Log("collision");
		if (other.transform.tag == "Enemy" && _enemyFind == false) { 
			if (_collChk == false) {

				_enemyFind = true;
				_enemy = other.gameObject;			
				_collChk = true;

				_disVec = (_enemy.transform.position - transform.position);
				//Debug.Log(_disVec.magnitude);
				_adj = ((_disVec.magnitude/_radius) + 1.0f) * _timeForColl;
				// _adj adjust the difference of velocity as radius

				/* Force Calculation */
				_A = transform.position.x - _v0Vec.x / Mathf.Sqrt(((transform.position.x - _v0Vec.x) * (transform.position.x - _v0Vec.x)) + ((transform.position.z - _v0Vec.z) * (transform.position.z - _v0Vec.z)));  
				//Debug.Log(_A);
				_B = transform.position.z - _v0Vec.z / Mathf.Sqrt(((transform.position.x - _v0Vec.x) * (transform.position.x - _v0Vec.x)) + ((transform.position.z - _v0Vec.z) * (transform.position.z - _v0Vec.z)));  
				//Debug.Log(_B);
				_fVec.x = (2.0f * (_enemy.transform.position.x - (_v0Vec.x * _timer * _A * _adj) - (transform.position.x))) / (_adj * _adj);
				//Debug.Log(_fVec.x);
				_fVec.z = ((2.0f * (_enemy.transform.position.z - (_v0Vec.z * _timer * _B * _adj) - (transform.position.z))) / (_adj * _adj));
				//Debug.Log(_fVec.z);
				_fVec.y = 0.0f;

				/* change the direction */
				_missile.transform.up = _fVec;
				transform.up = _fVec;
			
			}
		}
	}

	/* This method verify the target is in fAngle */
	bool IsInAngle (GameObject target, float fAngle) {
		Vector3 vRelative = transform.InverseTransformPoint(target.transform.position - transform.position);
		float fDeg = Mathf.Atan2 (vRelative.x, vRelative.z) * Mathf.Rad2Deg;
		
		if(-fAngle / 2 <= fDeg && fDeg <= fAngle / 2)
			return true;
		
		return false;
	}
}