using UnityEngine;
using System.Collections;

public class auto_des : MonoBehaviour {
	public ParticleSystem f;
	public float time;
	// Use this for initialization
	void Start () {
		InvokeRepeating("timer", 1f, 0.1f);
		f.Play ();
		time = 0;
	}
	void timer (){
		time += 0.1F;
	}
	// Update is called once per frame
	void Update () {
		if (time > 0.3f) {
			Destroy (this.gameObject);
		}
	}
}
