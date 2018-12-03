using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DeathMenu : MonoBehaviour {

	public AudioSource deathSound;

	void Start () {
		//AudioSource[] audios = GetComponents<AudioSource> ();
		//deathSound = audios [0];
		GameObject bgm = GameObject.Find ("BackgroundMusicPermanent(Clone)");
		Destroy (bgm);

	}

	void Awake () {
		
	}

	public void mainMenu () {
		Time.timeScale = 1;
		GameObject bgm = GameObject.Find ("BackgroundMusicDeath");
		Destroy (bgm);
		SceneManager.LoadScene ("MainMenu");
	}

}
