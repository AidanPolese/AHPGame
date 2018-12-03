using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyPace : MonoBehaviour {
	private float moveX;
	public float moveSpeed = 1;
	public float timer;
	public float ChangeDirection = 3;
	public string direction = "Right";
	public int health = 2;
	public AudioSource deathSound;
	public int lifeTime = 2;

	void Start () {
		gameObject.tag = "Enemy";
		timer = ChangeDirection; //starts the timer at enough speed, so it doesnst pause at start.
	}

	// Update is called once per frame
	void Update () {
		//timer += Time.deltaTime;
		if (health <= 0) {

			StartCoroutine (die());
		}//end health if
		/*
		if (timer > ChangeDirection && direction == "Right") {
			timer = 0;
			direction = "Left";
			moveXPosRight ();
		} 
		if (timer > ChangeDirection && direction == "Left") {
			timer = 0;
			direction = "Right";
			moveXPosLeft ();
		}
		*/
	}

	IEnumerator die () {
		Debug.Log ("made it to die");
		GetComponent<AudioSource> ().Play ();
		Debug.Log ("playsound");
		yield return new WaitForSeconds (5);
		Destroy(gameObject);
	}

	void moveXPosRight () {
		moveX = 1;
		GetComponent<Rigidbody2D> ().velocity = new Vector2 (moveX * moveSpeed, 0);
	}

	void moveXPosLeft() {
		moveX = -1;
		GetComponent<Rigidbody2D> ().velocity = new Vector2 (moveX * moveSpeed, 0);
	}
}//end class