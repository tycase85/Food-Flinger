using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Projectile : MonoBehaviour {

	public Rigidbody2D rb;
	public Rigidbody2D hook;

	public float releaseTime = .15f;
	public float maxDragDistance = 2f;
	public float reloadTime = .5f;

	public GameObject nextBall;

	private bool isPressed = false;

	int count = 0;
	int amount = 5;

	void Update ()
	{
		if (isPressed)
		{
			
			Vector2 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);

			if (Vector3.Distance(mousePos, hook.position) > maxDragDistance)
				rb.position = hook.position + (mousePos - hook.position).normalized * maxDragDistance;
			else
				rb.position = mousePos;
		}

		if (Input.GetKeyDown ("space")) {
			SceneManager.LoadScene (SceneManager.GetActiveScene ().buildIndex);
		}

		if (rb.IsSleeping () == true) {
			StopCoroutine (Release ());
		}
	
	}



	void OnMouseDown ()
	{
		isPressed = true;
		rb.isKinematic = true;
	}

	void OnMouseUp ()
	{
		isPressed = false;
		rb.isKinematic = false;
			
		StartCoroutine (Release ());
		
	}



	IEnumerator Release ()
	{
		yield return new WaitForSeconds(releaseTime);

		GetComponent<SpringJoint2D>().enabled = false;
		this.enabled = false;

		yield return new WaitForSeconds (reloadTime);
		count++;

		if(count > amount)
			Instantiate (nextBall);
			nextBall.GetComponent<SpringJoint2D> ().enabled = true;
			nextBall.GetComponent<Projectile>().enabled = true;
			nextBall.transform.position = new Vector3 (-0.6f, 0.83f, 0);
			nextBall.transform.rotation = new Quaternion (0, 0, 0, 0);
			nextBall.SetActive(true);




	}

}