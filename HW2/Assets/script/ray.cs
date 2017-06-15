using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class ray : MonoBehaviour {
	public static float time; 
	public bool shot;
	public float shot_next;
	public GameObject fire;
	public float fire_time;
	public static float enemy_count;
	public float call_enemy_count;
	public static int money;
	public static float enemy_wave;
	public float next_enemy_time;
	public GameObject menu;
	public bool isShowing;
	// Use this for initialization
	void Start () {
		InvokeRepeating("timer", 1f, 0.1f); // gaming count ex.123456789 ("function_name", start_time, every_time_execute)
		shot_next = 0;
		shot = false;
		fire.SetActive (false);
		fire_time = 0;
		call_enemy_count = -1; // not calling
		money = 0;
		enemy_count = -1;
		enemy_wave = 1;
		next_enemy_time = 1f;
		isShowing = false;
		menu.SetActive(isShowing); // initialize the shop_menu
	}
	void timer (){ // timing count ex.123456789 function
		time += 0.1F;

		//if (shot_next < time) {
		//	shot = true;
		//}
	}
	void enemyCountdown (){
		enemy_count -= 0.1F;
	}
	// Update is called once per frame
	void Update () {
		RaycastHit hit;
		shot_next += Time.deltaTime;
		if (!shot && shot_next > 0.5f) {
			shot = !shot;
		}

		if(Physics.Raycast(transform.position, transform.forward, out hit, 100.0f))
		{
			Debug.DrawLine(transform.position, hit.point);
		}

		if(Input.GetMouseButton(0) && shot)
		{
			if(hit.collider.gameObject.tag == "enemy"){
				enemy_nav tmp = hit.collider.gameObject.GetComponent<enemy_nav> ();
				tmp.setLife(tmp.getLife() - 3);
			}
			fire.SetActive (true);
			fire_time = time + 0.1f;
			shot = false;
			shot_next = 0;
			//shot_next = time + 1f;
		}
		if (fire_time < time) {
			fire.SetActive (false);
		}
		if(time >= 20){ // time large than 100
			SceneManager.LoadScene(2); // success scene
			PlayerPrefs.SetString("name4", "無名");
			PlayerPrefs.SetInt("score4", money);
			print(money);
		}
		if( (time > next_enemy_time) && (time < (next_enemy_time + 1f) ) && call_enemy_count == -1){ // enemy count down
			call_enemy_count = 1;
			enemy_count = 10; // enemy_count setup
			InvokeRepeating("enemyCountdown", 1f, 0.1f);
			create_enemy.enemy_start = -1; // enemy stop create
		}
		if(enemy_count <= 0 && call_enemy_count == 1){ // cancel count down and next enemy time is 20s later
			CancelInvoke("enemyCountdown");
			call_enemy_count = -1;
			enemy_wave += 1;
			next_enemy_time = time + 20;
			create_enemy.enemy_start = 1; // enemy create create
		}

		if (Input.GetKeyDown("escape")) {
             isShowing = !isShowing;
             menu.SetActive(isShowing);
         }

	}
	void OnGUI(){
		GUI.Box(new Rect(10,10,150,30), "Time: " + time.ToString("0.0"));
	}
}
