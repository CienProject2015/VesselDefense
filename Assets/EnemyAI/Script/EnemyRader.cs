using UnityEngine;
using System.Collections;

public class EnemyRader : MonoBehaviour {

	public GameObject Order;
	private ManagementNotation noteM;
	void Start () {
		//noteM = new ManagementNotation(gameObject);
		//transform.localScale = new Vector3(10, 10, 10);
	}

	void Update () {
		//noteM.Update(Order);
	}

	void OnTriggerEnter(Collider coll){
		if(coll.tag != "Enemy"){
			//noteM.AddObject(coll.transform.gameObject);
		}
	}

	void OnTriggerExit(Collider coll){
		if(coll.tag != "Enemy"){
			//noteM.DeleteObject(coll.transform.gameObject);
		}
	}

	void Target(GameObject obj){}
	void ForgetTarget(){}
	void Engine(bool On){}
	void Torque(bool On){}
}

class ManagementNotation{
	public Notation Head;
	private GameObject OrderObj;
	
	public ManagementNotation(GameObject obj){
		Head = new Notation(obj);
		OrderObj = obj;
	}
	
	public void AddObject(GameObject obj){
		Notation newNote = new Notation(OrderObj);
		newNote.SetObject(obj);
		Head.AddNote(newNote);
	}
	
	public void DeleteObject(GameObject obj){
		Head.DeleteObject(obj);
	}
	
	public void Update(GameObject Order){
		Head.Update(Order);
	}
}

class Notation{
	private GameObject OrderObj;
	public GameObject notationObject;
	public Vector3 notationVec;
	public float notationDanger;
	public Notation next, prev;
	public bool bnext, bprev;
	
	public Notation(GameObject Order){
		bnext = bprev = false;
		OrderObj = Order;
		notationObject = null;
		notationVec = new Vector3(0, 0, 0);
		notationDanger = 0.0f;
	}
	
	public void SetObject(GameObject obj){
		notationObject = obj;
		notationVec = obj.transform.position;
	}
	
	private void CalculateDanger(){
		if(notationObject != null){
			if(notationObject.transform.position != notationVec){
				Vector3 e = Vector3.Normalize( notationObject.transform.position - notationVec );
				Vector3 m = Vector3.Normalize( OrderObj.transform.position - notationVec );
				notationDanger = Vector3.Dot(e, m);
				notationVec = notationObject.transform.position;
			}
		}
	}
	
	public void AddNote(Notation newNote){
		if(bnext){
			this.next.AddNote(newNote);
		}else{
			this.next = newNote;
			newNote.prev = this;
			bnext = newNote.bprev = true;
		}
	}
	
	public void DeleteNote(){
		if(bnext||this.next!=null){
			prev.next = this.next;
		}else{
			if(bprev){
				prev.bnext = false;
			}
		}
	}
	
	public void DeleteObject(GameObject obj){
		if(obj == notationObject){
			if(bnext){
				prev.next = this.next;
			}else{
				prev.bnext = false;
			}
		}else{
			if(bnext){
				this.next.DeleteObject(obj);
			}
		}
	}
	
	public void Update(GameObject Order){
		if(OrderObj != null){
			DeleteNote();
		}
		CalculateDanger();
		if(0.5f < notationDanger){
			new Sender(Order, "CloseObject", notationObject);
		}
		if(bnext){
			this.next.Update(Order);
		}
	}
	
	
}

class Sender : MonoBehaviour{
	public GameObject SendObject;
	
	public Sender(GameObject Gobj, string Message, object obj){
		SendObject = Gobj;
		Sending(Message, obj);
	}
	
	public void Sending(string Message, object obj){
		SendObject.SendMessage(Message, obj);
	}
}