using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class ranking : MonoBehaviour {

	public Text rank1;
	public Text rank2;
	public Text rank3;

	public string[] name;
	public int[] score;
	// Use this for initialization
	void Start () {
		name = new string[4];
		name[0] = PlayerPrefs.GetString("name1");
		name[1] = PlayerPrefs.GetString("name2");
		name[2] = PlayerPrefs.GetString("name3");
		name[3] = PlayerPrefs.GetString("name4");

		score = new int[4];
		score[0] = PlayerPrefs.GetInt("score1");
		score[1] = PlayerPrefs.GetInt("score2");
		score[2] = PlayerPrefs.GetInt("score3");
		score[3] = PlayerPrefs.GetInt("score4");

		print(score[3]);


		
		for (int i = 3 ; i > 0; --i){
            for (int j = 0; j < i; ++j){
                if (score[j] < score[j + 1]){
					string temp = name[j];
					name[j] = name[j+1];
					name[j+1] = temp;
					int temp_s = score[j];
					score[j] = score[j+1];
					score[j+1] = temp_s;
				}
			}
		}
		

		PlayerPrefs.DeleteAll(); // clear all		
		rank1.text = name[0] + "  " + score[0] ;
		rank2.text = name[1] + "  " + score[1] ;
		rank3.text = name[2] + "  " + score[2] ;
		print (name[0]);
		print (name[1]);
		print (name[2]);
		print (score[0]);
		print (score[1]);
		print (score[2]);

		PlayerPrefs.SetString("name1", "無名");
		PlayerPrefs.SetString("name2", "無名");
		PlayerPrefs.SetString("name3", "無名");

		PlayerPrefs.SetInt("score1", score[0]);
		PlayerPrefs.SetInt("score2", score[1]);
		PlayerPrefs.SetInt("score3", score[2]);

	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
