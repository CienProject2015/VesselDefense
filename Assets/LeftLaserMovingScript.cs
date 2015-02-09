using UnityEngine;
using System.Collections;

public class LeftLaserMovingScript : MonoBehaviour
{
		
		private string key;
		public GameObject rightLaser;
		// Use this for initialization
		void Start ()
		{
				this.key = "1";
				rightLaser.GetComponent<RightLaserMovingScript> ().enabled = false;
		}
	
		// Update is called once per frame
		void Update ()
		{			
				controlRotation (); //f 와 g를 누를 시 왼쪽 오른쪽으로 공격방향 바뀜.
				if (Input.GetKeyDown (key)) {
						switchControl (); //처음 Default는 Left 먼저, 한번 더 같은 키 누르면 right로 control 변경.
				}

		}
	
		void setKey (string key)
		{
				this.key = key;
		}

		void controlRotation ()
		{
				if (Input.GetKey ("f")) {
						gameObject.transform.Rotate (0, -1, 0);
				}
				if (Input.GetKey ("g")) {
						gameObject.transform.Rotate (0, 1, 0);
				}
		}

		void switchControl ()
		{
				rightLaser.GetComponent<RightLaserMovingScript> ().enabled = true;		
				gameObject.GetComponent<LeftLaserMovingScript> ().enabled = false;
				//gameObject.SetActive (false);
				
		}

}
