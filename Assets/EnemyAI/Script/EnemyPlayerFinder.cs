using UnityEngine;
using System.Collections;

public class EnemyPlayerFinder : MonoBehaviour {
	
	void Start () {
		transform.localScale = new Vector3(100, 100, 100);
	}

	void Update () {
	
	}

	void OnTriggerEnter(Collider coll){
		if(coll.name == "PlayerCube"){
			transform.parent.SendMessage("Target", coll.transform.gameObject);
		}
	}

	void OnTriggerExit(Collider coll){
		if(coll.name == "PlayerCube"){
			transform.parent.SendMessage("ForgetTarget");
		}
	}

	void Target(GameObject obj){}
	void ForgetTarget(){}
	void Engine(bool On){}
	void Torque(bool On){}
}
