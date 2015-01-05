using UnityEngine;
using System.Collections;

public class SyScript : MonoBehaviour {

	public int hp;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKey("w")) {
			gameObject.transform.position += new Vector3(0, 0, 1);
		}
		if (Input.GetKey("a")) {
			gameObject.transform.position += new Vector3(-1, 0, 0);
		}
		if (Input.GetKey("s")) {
			gameObject.transform.position += new Vector3(0, 0, -1);
		}
		if (Input.GetKey("d")) {
			gameObject.transform.position += new Vector3(1, 0, 0);
		}
	}

	void Damage (int damage) {
		hp -= damage;
	}
}
