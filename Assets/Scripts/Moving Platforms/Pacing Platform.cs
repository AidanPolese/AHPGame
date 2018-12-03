using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PacingPlatform : MonoBehaviour {
	private float moveX;
	public float moveSpeed = 1;
	public float timer;
	public float ChangeDirection = 3;
	public string direction = "Right";

	// Update is called once per frame
	void FixedUpdate () {
		timer += Time.deltaTime;
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
