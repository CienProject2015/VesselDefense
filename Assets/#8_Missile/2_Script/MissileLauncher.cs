using UnityEngine;
using System.Collections;

public class MissileLauncher : MonoBehaviour {

	public GameObject _playerShip;
	public Transform _missile;
	private PlayerScript _playerSt;

	// Use this for initialization
	void Start () {

		_playerSt = _playerShip.GetComponent<PlayerScript>();
	}
	
	// Update is called once per frame
	void Update () {
	
		if ( _playerShip != null && _playerSt._attackChk == true) {
			float posX = transform.position.x;
			float posY = transform.position.y;
			float posZ = transform.position.z;
			Vector3 _missileLaunchPos = new Vector3(posX, posY, posZ) + transform.up * 1.5f;
			Instantiate (_missile, _missileLaunchPos, transform.rotation);
			_playerSt._attackChk = false;
		}
	}
}
