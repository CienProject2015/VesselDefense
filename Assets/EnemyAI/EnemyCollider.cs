using UnityEngine;
using System.Collections;

public class EnemyCollider : MonoBehaviour {
	public GameObject Order;

	void Start () {
		transform.localScale = new Vector3(10, 10, 10);
	}

	void Update () {
		
	}

	void OnTriggerEnter(Collider coll){
		if(coll.name == "PlayerCube"){
			Order.SendMessage("ThereIsVessel", coll.transform.gameObject);
		}
	}
}
