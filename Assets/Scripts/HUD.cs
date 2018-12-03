using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HUD : MonoBehaviour {

	//to select image
	public Sprite[] HeartSprites;
	//image on the screen
	public Image HearthsUI;
	private PlayerHealthSystem playerHealth;

	void Start(){
		playerHealth = GameObject.FindGameObjectWithTag ("Player").GetComponent<PlayerHealthSystem> ();
	}

	void Update(){
		//This ensures index is never out of range.(even if game over screen isnt called).
		if (playerHealth.health > 0) {
			HearthsUI.sprite = HeartSprites [playerHealth.health - 1]; //-1 bc i dont have an image w 0 hearts.
		}
	}
}
