using UnityEngine;
using System.Collections;

public class EnemyAI : MonoBehaviour {

	//public int EnemyVersion = 0;
	
	private int timer = 0;

	private GameObject player;
	private GameObject shuttle;



	void Start () {
		player = GameObject.Find("PlayerCube");
		//shuttle = GameObject.Find("Shuttle");
	}

	void Update () {
		timer++;
		if(timer==1){
			//rigidbody.AddForce(transform.forward*10);
			//SetEngineE(true);
			//SetTorqueE(true, true);
		}
		//LookAtPosition(player.transform.position);
		MovePosition(player.transform.position);
	}

	private void OffEngine(){
		SetEngineE(false);
		SetTorqueE(false, false);
	}

	private void ApproachPosition(Vector3 pos){
		LookAtPosition(pos);
		if( 0.95f<Vector3.Dot(transform.forward, Vector3.Normalize(pos-gameObject.transform.position))){
			SetEngineE(true);
		}else{
			SetEngineE(false);
		}
	}

	private void FarAwayPosition(Vector3 pos){
		LookAtPosition(2*transform.position - pos);
		if(Vector3.Dot(transform.forward, Vector3.Normalize(pos-gameObject.transform.position)) < -0.95f){
			SetEngineE(true);
		}else{
			SetEngineE(false);
		}
	}

	private void MovePosition(Vector3 pos){
		if(20 < Vector3.Distance(pos, transform.position)){
			ApproachPosition(pos);
		}else{
			if(5<Vector3.Distance(Vector3.zero, GetComponent<Rigidbody>().velocity)){
				FarAwayPosition(pos);
			}else{
				SetEngineE(false);
			}
		}
	}

	private void RotateAroundObject(GameObject obj, bool right){
		Vector3 pos = transform.position - obj.transform.position;
		if(right){
			if(50 < Vector3.Distance(pos, Vector3.zero)){
				ApproachPosition(obj.transform.position);
			}else if(Vector3.Distance(pos, Vector3.zero) < 40){
				FarAwayPosition(obj.transform.position);
			}else{
				pos = Vector3.Normalize( new Vector3(pos.z , pos.y, -pos.x));
				//pos += transform.position;
				LookAtPosition(pos + transform.position);
				if(0.95f<Vector3.Dot(transform.right, Vector3.Normalize(obj.transform.position-gameObject.transform.position))){
					SetEngineE(true);
				}else{
					SetEngineE(false);
				}
			}
		}else{
			if(50 < Vector3.Distance(pos, Vector3.zero)){
				ApproachPosition(obj.transform.position);
			}else if(Vector3.Distance(pos, Vector3.zero) < 40){
				FarAwayPosition(obj.transform.position);
			}else{
				pos = Vector3.Normalize( new Vector3(-pos.z, pos.y, pos.x));
				//pos += transform.position;
				LookAtPosition(pos + transform.position);
				if(0.95f<Vector3.Dot(-transform.right, Vector3.Normalize(obj.transform.position-gameObject.transform.position))){
					SetEngineE(true);
				}else{
					SetEngineE(false);
				}
			}
		}

	}

	private void AvoidObject(GameObject obj){

	}

	private void LookAtPosition(Vector3 pos){
		if( 0<Vector3.Dot(transform.right, Vector3.Normalize(pos-transform.position))){//turn right
			if(0.8f<Vector3.Dot(transform.forward, Vector3.Normalize(pos-transform.position))){
				if(1<GetComponent<Rigidbody>().angularVelocity.y){
					SetTorqueE(true, false);
				}else if(GetComponent<Rigidbody>().angularVelocity.y < 0){
					if(Vector3.Dot(transform.forward, Vector3.Normalize(pos-transform.position))<0.999f){
						SetTorqueE(true, true);
					}
				}else{
					SetTorqueE(false, true);
				}
			}else{
				SetTorqueE(true, true);
			}

		}else{//turn left
			if(0.8f<Vector3.Dot(transform.forward, Vector3.Normalize(pos-gameObject.transform.position))){
				if(GetComponent<Rigidbody>().angularVelocity.y < -1){
					SetTorqueE(true, true);
				}else if(0 < GetComponent<Rigidbody>().angularVelocity.y){
					if(Vector3.Dot(transform.forward, Vector3.Normalize(pos-gameObject.transform.position))<0.999f){
						SetTorqueE(true, false);

					}
				}else{
					SetTorqueE(false, true);
				}
			}else{
				SetTorqueE(true, false);
			}
		}
	}

	private void SetEngineE(bool en){
		gameObject.SendMessage("Engine", en);
	}

	private void SetTorqueE(bool On, bool right){
		gameObject.SendMessage("Torque", On);
		gameObject.SendMessage("TorqueDirection", right);
	}
	

}
