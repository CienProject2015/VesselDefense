using UnityEngine;
using System.Collections;

public class EnemyAI : MonoBehaviour {

	public int EnemyVersion = 0;
	public Vector3 vurtualForce;

	void Start () {
		vurtualForce = new Vector3(0,0,0);
	}

	void Update () {
		move ();
		transform.position += vurtualForce;
	}

	void move(){
		OnEngine();
		OnRotate("right");
	}

	void OnEngine(){
		vurtualForce += transform.forward*0.01f;
	}

	void OnRotate(string rot){
		if(rot == "right"){
			transform.Rotate(new Vector3(0,1,0));
		}
		if(rot == "left"){
			transform.Rotate(new Vector3(0,-1,0));
		}
	}
}
