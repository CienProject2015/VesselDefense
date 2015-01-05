using UnityEngine;
using System.Collections;

public class SomeThing : MonoBehaviour {
	public int hp = 1000;
	public Transform hpBar, explosion, goalEffect;
	private Vector3 myPos;

	void Start () {
		myPos = transform.position;
		hpBar.transform.localScale = new Vector3((float)(hp/300), 0.1f, 0.1f);

	}

	void Update () {
		myPos += new Vector3(0.1f, 0, 0);
		transform.position = myPos;
		if(hp<=0){
			Instantiate(explosion, transform.position, transform.rotation);
			Destroy(gameObject);
		}
	}

	void Damage(int damage){
		hp-=damage;
		hpBar.transform.localScale = new Vector3((float)(hp/300), 0.1f, 0.1f);
	}

	void OnTriggerEnter(Collider coll){
		if(coll.transform.gameObject.tag == "goal"){
			Instantiate(goalEffect, transform.position, transform.rotation);
			Destroy(gameObject);
		}
	}
}
