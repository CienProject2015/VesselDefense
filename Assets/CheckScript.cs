using UnityEngine;
using System.Collections;

public class CheckScript : MonoBehaviour {
	public GameObject Laser1;
	public GameObject Laser2;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
				if (Laser2.transform.eulerAngles.y + Laser1.transform.eulerAngles.y > 360) {

				} else {

				}
		}
}
