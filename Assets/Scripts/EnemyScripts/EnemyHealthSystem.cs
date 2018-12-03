using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealthSystem : MonoBehaviour {
	public int health = 2;
	public AudioSource death;
	public GameObject player;
	public Rigidbody2D playerRigidBody;
	public float gravityDecrease = 0.02f;
	public float lowestGravity = 0.5f;
	// Use this for initialization
	// Update is called once per frame
	void Start () {
		death = GetComponent<AudioSource>();
		player = GameObject.FindGameObjectWithTag ("Player");
		playerRigidBody = player.GetComponent<Rigidbody2D> ();
	}

	void Update () {
		if (health <= 0) { //the enemy is now dead.
			AudioSource.PlayClipAtPoint(death.clip, Camera.main.transform.position);
			if (playerRigidBody.gravityScale > lowestGravity) {
				playerRigidBody.gravityScale -= gravityDecrease;
			}
			Destroy(gameObject);
			//Destroy(gameObject);
		}
	}

	IEnumerator die () {
		Debug.Log ("made it to die");
		GetComponent<AudioSource> ().Play ();
		Debug.Log ("playsound");
		yield return new WaitForSeconds (2);
		Destroy(gameObject);
	}

	void Damage(int damage){
		//commented out line is the one that will make them flash red when they get hit, we just need the animation.
		//gameObject.getComponent<Animation>().Play(red_enemy);
		health -= damage;
	}//end Damage
}