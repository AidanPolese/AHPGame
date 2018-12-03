using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerHealthSystem : MonoBehaviour {
	public int health = 3;
	public AudioSource jumpSound1;
	public AudioSource jumpSound2;
	public AudioSource swordSound;
	public AudioSource damageSound;
	public float timer;
	public int invisabilityTimer = 1;

	void Start () {
		timer = 0;
		AudioSource[] audios = GetComponents<AudioSource> ();
		jumpSound1 = audios [0];
		jumpSound2 = audios [1];
		swordSound = audios [2];
		damageSound = audios [3];
	}

	void Update () {
		timer += Time.deltaTime;
		if (health <= 0) {
			GameObject bgm = GameObject.Find ("BackgroundMusicPermanent");
			Destroy (bgm);
			SceneManager.LoadScene ("DeathMenu");
		}//end if
	}
	//Tom Added
	void playerDamage(int damage) {
		//commented out line is the one that will make them flash red when they get hit, we just need the animation.
		//gameObject.getComponent<Animation>().Play(red_player);
		if (timer > invisabilityTimer) {
			damageSound.Play();
			timer = 0;
			health -= damage;	
		}
	}
}//end class

