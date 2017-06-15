using UnityEngine;
using System.Collections;


public class create_enemy : MonoBehaviour {
	public static float time;
	public float rate;
	public Transform enemy;
	public static int enemy_start;
	public int each_enemy;
	public static int enemy_number;

	// Use this for initialization
	void Start () {		
		each_enemy = 1;
		enemy_number = 0;
	}
	void timer(){
		time += rate;
		enemy_number += 1;
		Instantiate(enemy, new Vector3(this.transform.position.x + Random.Range(-10f, 10f), 24f, this.transform.position.z + Random.Range(-10f, 10f)), transform.rotation);
	}
	// Update is called once per frame
	void Update () {		
		if(enemy_start == 1 && each_enemy == 1){
			rate = 7f;
			float start = Random.Range (1f, 3f);
			InvokeRepeating("timer", start, rate);
			each_enemy = 0;
		}
		if(enemy_start == -1){
			CancelInvoke("timer");
			each_enemy = 1;
		}
		if (time > 30) {
			rate = 5f;
		}
		if (time > 60) {
			rate = 3f;
		}

	}
}
