using UnityEngine;
using System.Collections;

public class HP_a123 : MonoBehaviour {
	public static float maxhp;
	public static float hp;
	// Use this for initialization
	void Start () {
	}

	// Update is called once per frame
	void Update () {
		this.transform.localPosition = new Vector3 ( (-2.75f + 2.75f * ( hp / maxhp ) ), 0.0f, 0.0f);
	}
}
