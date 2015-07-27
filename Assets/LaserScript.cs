using UnityEngine;
using System.Collections;

public class LaserScript : MonoBehaviour
{
		private bool turnOnLaser = false;
		private LineRenderer line;
		// Use this for initialization
		void Start ()
		{
				line = gameObject.GetComponent<LineRenderer> ();
				line.enabled = false;//버튼 누르기 전에는 레이저가 안보이게 		

		}
	
		// Update is called once per frame
		void Update ()
		{
				if (Input.GetButtonDown ("Fire1")) {
						turnOnLaser = true;
						StopCoroutine ("FireLaser");
						StartCoroutine ("FireLaser");
				}

		}

		IEnumerator FireLaser ()
		{
				line.enabled = true;
				//gameObject.GetComponent<Light> ().enabled = true;
				while (turnOnLaser) {
						line.GetComponent<Renderer>().material.mainTextureOffset = new Vector2 (0, Time.time);
						Ray ray = new Ray (transform.position, transform.forward);
						RaycastHit hit;
						line.SetPosition (0, ray.origin);
						if (Physics.Raycast (ray, out hit, 100)) {
								line.SetPosition (1, hit.point);
								if (hit.collider.transform.tag == "Enemy" || hit.collider.transform.tag == "EnemyBody") {
										hit.transform.gameObject.SendMessage ("Damage", 10);
								} else if (hit.collider.gameObject.tag == "Laser") {
										line.SetPosition (1, ray.GetPoint (100));										
								}
						} else {
								line.SetPosition (1, ray.GetPoint (100));
						}
						yield return null;
				}

				line.enabled = false;
				//gameObject.GetComponent<Light> ().enabled = false;
		}
}
