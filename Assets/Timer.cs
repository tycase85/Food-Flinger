using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Timer : MonoBehaviour {

	public Text time;
	public Rigidbody2D ball1;
	public Rigidbody2D ball2;
	public Rigidbody2D ball3;
	public Rigidbody2D ball4;
	public Rigidbody2D ball5;

	public GameObject menu;


	public float timer = 90.0f;


	// Update is called once per frame
	void Update () {


		timer -= Time.deltaTime;
		time.text = " " + timer;
		if (timer < 0) {
			timer = 0;
			menu.SetActive(true);
			time.text = "0";
			ball1.Sleep ();
			ball2.Sleep ();
			ball3.Sleep ();
			ball4.Sleep ();
			ball5.Sleep ();

		}
		
	}
}
