using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class time : MonoBehaviour {

	// Use this for initialization
	public Text txt;
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		txt.text = "距離下一波敵人還有" + ray.enemy_count.ToString("0.0") + "秒";
	}
}
