using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlobEnemyMove : MonoBehaviour {

	public LayerMask enemyMask;
	public float speed = 5f;
	Rigidbody2D myBody;
	Transform myTrans;
	float myWidth;

	// Use this for initialization
	void Start () {
		myTrans = this.transform;
		myBody = this.GetComponent<Rigidbody2D> ();
		myWidth = this.GetComponent<SpriteRenderer> ().bounds.extents.x;
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		//Check for ground so it can turn around
		Vector2 lineCastPos = myTrans.position - myTrans.right * myWidth;
		bool isGrounded = Physics2D.Linecast (lineCastPos, lineCastPos + Vector2.down, enemyMask);

		//if there is no ground turn around
		if (!isGrounded) {
			Vector3 currRot = myTrans.eulerAngles;
			currRot.y += 180;
			myTrans.eulerAngles = currRot;
		}

		//Always move forward
		Vector2 myVel = myBody.velocity;
		myVel.x = -myTrans.right.x * speed;
		myBody.velocity = myVel;
	}
}
