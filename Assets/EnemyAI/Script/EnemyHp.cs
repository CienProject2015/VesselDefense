using UnityEngine;
using System.Collections;

public class EnemyHp : MonoBehaviour {

	public int Hp = 100;
	private int FirstHp;
	private float HpRate;

	void Start () {
		FirstHp = Hp;
	}

	void Update () {
		
	}

	void Damage(int damage){
		Hp-=damage;
		if(Hp <= 0){
			gameObject.SendMessage("ZeroHP");
		}else{
			HpRate = (float)Hp/(float)FirstHp;
			GetComponent<Renderer>().material.color = Color.red + Color.blue*HpRate + Color.yellow*HpRate;
			//renderer.material.
		}
	}
}
