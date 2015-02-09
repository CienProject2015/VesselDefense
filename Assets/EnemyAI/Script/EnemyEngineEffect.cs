using UnityEngine;
using System.Collections;

public class EnemyEngineEffect : MonoBehaviour {

	public int limitFrame = 60;
	private int timer = 0;

	void Start () {
	
	}

	void Update () {
		timer++;
		if(limitFrame < timer){
			Destroy(gameObject);
		}
	}
}
