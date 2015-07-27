using UnityEngine;
using System.Collections;

public class EnemyMove : MonoBehaviour {
	
	public bool isEngine;
	public bool isTorque;
	public bool isMain = false;
	public float engineForce = 0;
	public float torqueForce = 0;
	public Transform EngineEffect;
	public Transform TorqueEffect;
	public Transform DestroyObject;
	public float mass = 1;
	private bool EngineOn;
	private bool TorqueOn;
	private bool sendedMass = false;
	private bool sendedEngine = false;
	private bool sendedTorque = false;
	private int timer = 0;

	void Start () {
		if(transform.childCount == 0){
			transform.parent.SendMessage("SetMass", mass);
			transform.parent.SendMessage("SetEngine", engineForce);
			transform.parent.SendMessage("SetTorque", torqueForce);
		}
	}

	void Update () {
		if(!transform.parent){
		}
		if(isMain){
			if(EngineOn){
				GetComponent<Rigidbody>().AddForce(transform.forward * engineForce);
			}
			if(TorqueOn){
				GetComponent<Rigidbody>().AddTorque(new Vector3(0, 1, 0) * torqueForce * 0.1f);
			}
		}
		if(isEngine || isTorque){
			timer++;
			if(100 < timer)timer = 0;
		}
		if(isEngine){
			if(EngineOn){
				if(timer%3==0)
					Instantiate(EngineEffect, transform.position, transform.rotation);
			}
		}
		if(isTorque){
			if(TorqueOn){
				if(timer%3==0)
					Instantiate(TorqueEffect, transform.position, transform.rotation);
			}
		}
	}

	void Engine(bool On){
		EngineOn = On;
		for(int i =0; i< transform.childCount; i++){
			transform.GetChild(i).SendMessage("Engine", On);
		}
	}
	void Torque(bool On){
		TorqueOn = On;
		for(int i =0; i< transform.childCount; i++){
			transform.GetChild(i).SendMessage("Torque", On);
		}
	}
	void TorqueDirection(bool right){
		if(0<torqueForce){
			if(!right){
				torqueForce *= -1;
			}
		}else{
			if(right){
				torqueForce *= -1;
			}
		}
	}
	
	void SetMass(float m){
		if(isMain){
			mass += m;
			GetComponent<Rigidbody>().mass = mass;
		}else{
			mass += m;
			if(sendedMass){
				transform.parent.SendMessage("SetMass", m);
			}else{
				transform.parent.SendMessage("SetMass", mass);
				sendedMass = true;
			}
		}
	}

	void SetEngine(float e){
		engineForce += e;
		if(!isMain){
			if(sendedEngine){
				transform.parent.SendMessage("SetEngine", e);
			}else{
				transform.parent.SendMessage("SetEngine", engineForce);
				sendedEngine = true;
			}
		}
	}

	void SetTorque(float t){
		torqueForce += t;
		if(!isMain){
			if(sendedTorque){
				transform.parent.SendMessage("SetTorque", t);
			}else{
				transform.parent.SendMessage("SetTorque", torqueForce);
			}
		}
	}

	void ZeroHP(){
		transform.parent.SendMessage("SetMass", -mass);
		transform.parent.SendMessage("SetEngine", -engineForce);
		transform.parent.SendMessage("SetTorque", -torqueForce);
		Instantiate(DestroyObject, transform.position, transform.rotation);
		Destroy(gameObject);
	}
}
