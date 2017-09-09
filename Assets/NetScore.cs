using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NetScore : MonoBehaviour {

	public Text scoreText;

	int score = 0;


	void OnCollisionEnter2D(Collision2D col){
		if (col.gameObject.tag == "Ball") {
			IncrementScore ();
		}
	}

	void IncrementScore(){
		score++;
		scoreText.text = " " + score;
	}

}
