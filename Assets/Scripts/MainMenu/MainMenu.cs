using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour {

	public GameObject MenuUI;

	void Start () {
		Time.timeScale = 1;

	}

	public void playClip () {
		gameObject.GetComponent<AudioSource> ().Play ();
	}

	public void playGame () {
		playClip ();
		GameObject aSource = GameObject.Find ("BackgroundMusic");
		Destroy (aSource);
		GameObject go = (GameObject)Instantiate(Resources.Load("BackgroundMusicPermanent")); ;
		SceneManager.LoadScene ("AidanLevel1");
	}

	public void quit () {
		playClip ();
		Application.Quit ();
	}
}
