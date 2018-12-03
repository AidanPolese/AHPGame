using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BatMove : MonoBehaviour {

	public float moveSpeed = 1;
	public float timer;
	public float ChangeDirection = 3;
	public string direction = "Right";
	public int health = 2;

	private float moveX;
	private Transform enemyTrans;

	void Start () {
		gameObject.tag = "Enemy";
		enemyTrans = this.GetComponent<Transform> ();
		timer = ChangeDirection; //starts the timer at enough speed, so it doesnst pause at start.
	}

	// Update is called once per frame
	void FixedUpdate () {
		timer += Time.deltaTime;
		if (timer > ChangeDirection && direction == "Right") {
			flip ();
			timer = 0;
			direction = "Left";
			moveXPosRight ();
		} 
		if (timer > ChangeDirection && direction == "Left") {
			flip ();
			timer = 0;
			direction = "Right";
			moveXPosLeft ();
		}
	}

	void flip () {
		Vector3 scale = enemyTrans.localScale;
		scale.x *= -1;
		enemyTrans.localScale = scale;
	}

	void moveXPosRight () {
		moveX = 1;
		GetComponent<Rigidbody2D> ().velocity = new Vector2 (moveX * moveSpeed, 0);
	}

	void moveXPosLeft() {
		moveX = -1;
		GetComponent<Rigidbody2D> ().velocity = new Vector2 (moveX * moveSpeed, 0);
	}
}
