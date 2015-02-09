using UnityEngine;
using System.Collections;

public class EnemyMissile : MonoBehaviour {

	private GameObject target;
	private Vector3 go = Vector3.zero;
	public int damage = 10;
	public float speed = 6f;


	void Start () {
	
	}

	void Update () {

	}

	void OnTriggerEnter(Collider coll){
		if(coll.tag != "EnemyBody" && coll.name != "PlayerCube" && coll.tag != "Enemy"){
			coll.SendMessage("Damage", damage);
			Destroy(gameObject);
		}
	}

	void Target(GameObject tar){
		target = tar;
		CalculateVec();
	}

	void CalculateVec(){
		go = Vector3.Normalize(target.transform.position - transform.position);
		rigidbody.velocity += go*speed;
	}
}
