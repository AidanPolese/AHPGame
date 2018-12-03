using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour {
	public int health = 2;
	/*
	public float timer;
	public int invisTime = 1; //how long the enemy is invisable after being hit (in seconds)
	// Use this for initialization
	void Start () {
		timer = 1; //This is a timer used to help determine if the enemy is in his invisablity stage (after being hit)
	}
	
	// Update is called once per frame
	void Update () {
		timer += Time.deltaTime; //updates the timer.
		if (health <= 0) { //the enemy is now dead.
			Destroy(gameObject);
		}
	}

	void Damage(int damage){
		health -= damage;
	}//end Damage

	 *Enemy health collision function. 
	void OnCollisionEnter2D(Collision2D other){
		if (other.gameObject.tag == "player_sword") {
			Debug.Log ("A");
			timer = 0; //reset the timer.
			if (timer > invisTime) {
				Debug.Log ("Enemy has been hit");
				//gameObject.getComponent<Animation>().Play(red_enemy);
				health -= 1;
			}
		}//end outter if
	}//end OnTriggerEnter2D
	*/
}//end class
