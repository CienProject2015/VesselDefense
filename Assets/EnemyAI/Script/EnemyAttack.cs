using UnityEngine;
using System.Collections;

public class EnemyAttack : MonoBehaviour {
	// If You SendMessage (Target, Object), this Script will be Automatically Attack!!
	public bool AttackAble;
	public Transform missile;
	public bool isMain = false;
	private GameObject findPlayerObj;
	private bool findPlayer = false;
	private int timer = 0;

	void Start () {
	}
	

	void Update () {
		if(AttackAble){
			timer++;
			if(30<timer){
				Attack();
				timer = 0;
			}
			/*
			if(isMain){
				if(100 < DistancePlayer()){
					findPlayer = false;
					ForgetTarget();
				}
			}
			*/
		}
	}

	
	void Attack(){
		if(findPlayer){
			Transform mis = (Transform)Instantiate(missile, transform.position, transform.rotation);
			mis.SendMessage("Target", findPlayerObj);
		}
	}

	float DistancePlayer(){
		if(findPlayer){
			return Vector3.Distance(transform.position, findPlayerObj.transform.position);
		}else{
			return 200;
		}
	}

	void ForgetTarget(){
		findPlayer = false;
		for(int i = 0; i < transform.childCount; i++){
			transform.GetChild(i).SendMessage("ForgetTarget");
		}
	}

	
	void Target(GameObject obj){
		findPlayerObj = obj;
		findPlayer = true;
		for(int i = 0; i < transform.childCount; i++){
			transform.GetChild(i).SendMessage("Target", obj);
		}
	}
}
