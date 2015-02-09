using UnityEngine;
using System.Collections;

public class EnemyDestroy : MonoBehaviour {

	private int timer = 0;
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		timer ++;
		if(500<timer){
			Destroy(gameObject);
		}
	}
}
