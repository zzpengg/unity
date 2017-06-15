using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class enemy_nav : MonoBehaviour {
	public Image blood;
	public Transform Target;  
	static public float maxhp;
	public float hp;
	public GameObject fire;
	NavMeshAgent NMA;
	// Use this for initialization
	void Start () {
		maxhp = 8;
		hp = 8;
		NMA = GetComponent<NavMeshAgent>();   //獲取NavMeshAgent component
		NMA.SetDestination(Target.position); 
		//fire.SetActive (false);
	}

	// Update is called once per frame
	void Update () {
		blood.transform.localPosition = new Vector3 ( (-2.75f + 2.75f * ( hp / maxhp ) ), 0.0f, 0.0f);
		if (hp <= 0) {
			ray.money += 10; // earn money 
			create_enemy.enemy_number -= 1;
			Instantiate(fire,this.transform.position,this.transform.rotation);            
			Destroy (this.gameObject);
		}
		
	}
	void OnTriggerEnter(Collider otherObject){
		if(otherObject.name == "a123"){
			Destroy (this.gameObject);
		}
	}

	public float getLife() {
		return hp;
	}

	public void setLife(float h) {
		hp = h;
	}
}
