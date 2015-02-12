using UnityEngine;
using System.Collections;

public class PlayerScript : MonoBehaviour
{
	
	// Player's basic properties	
	public float _speed; // player's move speed	
	public float _hp; // player's hp
	public bool _playerLive; // bool for player's live
	public bool _attackChk;

	
	// Use this for initialization
	void Start () { 
		_speed = 5.0f;
		_playerLive = true;
		_attackChk = false;
	}
	
	// Update is called once per frame
	void Update () {
		if(_playerLive)
		{

			if ((Input.GetAxis("Vertical") != 0 || Input.GetAxis("Horizontal") != 0))
			{
				float _verticalPos = Input.GetAxis("Vertical") * _speed * Time.deltaTime * 50;
				float _horizonPos = Input.GetAxis("Horizontal") * _speed * Time.deltaTime * 20;

				transform.Rotate(0, _horizonPos, 0);
				rigidbody.AddForce(transform.forward * _verticalPos); //(new Vector3(_horizonPos, 0, _verticalPos));
				//transform.localPosition += new Vector3(0, 0, _verticalPos);

			}

			if (Input.GetButtonDown("Fire1"))
			{
				_attackChk = true;
			}else{
				//_attackChk = false;
			}
			//_attackChk = false;
		}
	}
	
	void Damaged(float _dam)
	{
		_hp -= _dam;
		
		if(_hp >0)
		{

		}
		else if(_hp <= 0)
		{
			_playerLive=false;
		}
	}
}
