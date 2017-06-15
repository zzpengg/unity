using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class money : MonoBehaviour {

	// Use this for initialization
	public Text _money;
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		_money.text = ray.money.ToString("0");
	}
}
