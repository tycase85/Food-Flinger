using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Scorekeeping : MonoBehaviour {

	public Text scoreText;

	int score = 0;


	void OnTriggerEnter2D(Collider2D col){
		if (col.gameObject.name.Contains("Momo")) {		

			IncrementScore ();
			col.gameObject.SetActive (false);
		}



	}


	void IncrementScore(){
		score++;
		scoreText.text = " " + score;

	}

}
