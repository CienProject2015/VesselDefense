using UnityEngine;
using System.Collections;

public class LaserCollection : MonoBehaviour
{
		private LineRenderer line;
		private int collision = 0;
		private float charge = 0;
		private bool turnOnLaser = false;
		// Use this for initialization
		void Start ()
		{
				line = gameObject.GetComponent<LineRenderer> ();
				line.enabled = false;
				Debug.Log ("Start Laser Collecition");
		}
	
		// Update is called once per frame
		void Update ()
		{
				if (charge > 0) {
						charge *= 0.95f;
						Debug.Log ("Update : Charge = " + charge);
				}
		}

		public void OnTriggerEnter (Collider coll)
		{
				Debug.Log ("OnTriggerEnter" + "충돌한 물체= " + coll.name);
				collision = collision + 1;
				Debug.Log ("Collision 수 = " + collision);
				if (charge < 100) {
						charge += 0.01f;
				} 
		}
		
		public void OnTriggerStay (Collider coll)
		{
				Debug.Log (coll.name);
				if (charge < 100) {
						charge += 0.01f;
				} 
		}
		
		public void OnTriggerExit (Collider coll)
		{		
				Debug.Log ("OnTriggerExit");
				collision = collision - 1;
				if (collision == 0) {
						turnOnLaser = true;
						StopCoroutine ("FireLaser");
						StartCoroutine ("FireLaser");
				}
				Debug.Log ("OnTriggerExit" + collision);
		}

		IEnumerator FireLaser ()
		{		
				Debug.Log ("Fire");
				while (turnOnLaser) {	
						Debug.Log ("While Enter");
						line.enabled = true;
						line.GetComponent<Renderer>().material.mainTextureOffset = new Vector2 (0, Time.time);
						Ray ray = new Ray (transform.position, transform.forward);
						RaycastHit hit;
						line.SetPosition (0, ray.origin);
						if (Physics.Raycast (ray, out hit, 100)) {
								line.SetPosition (1, hit.point);
								if (hit.collider.transform.tag == "Enemy" || hit.collider.transform.tag == "EnemyBody") {
										hit.transform.gameObject.SendMessage ("Damage", 10);
								}
						} else {
								line.SetPosition (1, ray.GetPoint (100));
						}
						charge -= 0.000001f;
						if (charge < 0) {
								Debug.Log ("Charge is Oring ");
								turnOnLaser = false;
						}
						yield return null;
				}
				line.enabled = false;
		}
}


