using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JumpingEnemy : MonoBehaviour {

	public float jumpSpeed = 10f;
	public float jumpInterval = 100f;

	private Rigidbody2D enemyBody;
	private int jumpTimer = 0;

	//Animation
	Animator anim;
	public bool isGrounded;

	// Use this for initialization
	void Start () {
		enemyBody = this.GetComponent<Rigidbody2D>();
		anim = GetComponent<Animator>();
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		jumpTimer += 1;
		if (jumpTimer == jumpInterval) {
			jump ();
			jumpTimer = 0;
		}
	}

	void OnCollisionEnter2D(Collision2D coll) {
		isGrounded = true;
		anim.SetBool ("isGrounded", isGrounded);
	}

	private void jump() {
		enemyBody.velocity += jumpSpeed * Vector2.up;
		isGrounded = false;
		anim.SetBool ("isGrounded", isGrounded);
	}
}
