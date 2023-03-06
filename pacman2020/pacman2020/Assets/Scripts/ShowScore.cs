using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShowScore : MonoBehaviour {

	// Use this for initialization
	int score=0;
	public Text txtScore;
	void Start () {
		score = PlayerPrefs.GetInt ("Score");
	}
	
	// Update is called once per frame
	void Update () {
		txtScore.text = "Your Score is :" + score;
	}
}
