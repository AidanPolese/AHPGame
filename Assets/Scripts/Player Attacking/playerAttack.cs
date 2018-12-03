using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerAttack : MonoBehaviour {

	private bool attacking = false;
	private float attackTimer = 0;
	private float attackCD = 0.3f;
	private Animator anim;
	public AudioSource sound1;
	public AudioSource sound2;
	public AudioSource sound3;

	public Collider2D attackTrigger;


	void Awake(){
		anim = gameObject.GetComponent<Animator> ();
		attackTrigger.enabled = false;
		AudioSource[] audios = GetComponents<AudioSource> ();
		sound1 = audios [0];
		sound2 = audios [1];
		sound3 = audios [2];
	}//end awake

	void Update(){
		if (Input.GetKeyDown ("f") && !attacking) {
			attacking = true;
			attackTimer = attackCD;
			attackTrigger.enabled = true;
			sound3.Play ();
		}//end if

		if (attacking) {
			if (attackTimer > 0) {
				attackTimer -= Time.deltaTime;
			} else {
				attacking = false;
				attackTrigger.enabled = false;
			}
		}//end if 
		//set the animation bool attacking to the scripts attacking boolean.
		anim.SetBool("Attacking",attacking);
	}//end Update
}
