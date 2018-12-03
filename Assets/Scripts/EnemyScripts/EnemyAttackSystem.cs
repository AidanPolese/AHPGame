using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAttackSystem : MonoBehaviour {
	public int dmg = 1;
	/*
	 *Enemy health collision function. 
	*/
	void OnCollisionEnter2D(Collision2D other) {
		if (other.gameObject.tag == "Player") {
			other.gameObject.SendMessageUpwards ("playerDamage", dmg);
		}//end outter if
	}//end OnCollisionEnter2D
}
