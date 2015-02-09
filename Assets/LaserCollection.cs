using UnityEngine;
using System.Collections;

public class LaserCollection : MonoBehaviour
{
		private LineRenderer line;
		private float charge = 0;
		// Use this for initialization
		void Start ()
		{
				line = gameObject.GetComponent<LineRenderer> ();
				line.enabled = false;
		}
	
		// Update is called once per frame
		void Update ()
		{
				if (charge > 0) {
						charge *= 0.95f;

				}
		}

		public void shootLaser ()
		{		
				while (charge > 0) {			
						line.enabled = true;
						line.renderer.material.mainTextureOffset = new Vector2 (0, Time.time);
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
						charge -= 0.01f;
				}
		}

		public void OnTriggerEnter (Collider coll)
		{

				if (charge < 100) {
						charge += 1;
				} 
		}
		
		public void OnTriggerStay (Collider coll)
		{

				if (charge < 100) {
						charge += 1;
				} 
		}
		
		public void OnTriggerExit (Collider coll)
		{		
				Debug.Log ("Test");
				shootLaser ();
		}
}


