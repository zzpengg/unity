using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
public class a123 : MonoBehaviour {
	// Use this for initialization
	void Start () {
		HP_a123.maxhp = 100;
		HP_a123.hp = 100;
	}
	
	// Update is called once per frame
	void Update () {
		if (HP_a123.hp <= 0) {
			SceneManager.LoadScene(3);
		}
			
	}
	void OnTriggerEnter(Collider otherObject){
		if(otherObject.tag == "enemy"){
			HP_a123.hp -= 5;
		}
	}
	void OnGUI(){
		GUI.Box(new Rect(10,55,150,30), "HP: " + HP_a123.hp);
	}
}
