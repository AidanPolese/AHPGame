using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseScript : MonoBehaviour {

	public GameObject PauseUI;

	private bool paused = false;

	void Start () {
		PauseUI.SetActive (false);

	}

	void Update () {
		if(Input.GetButtonDown("Pause")) {
			paused = !paused;			
		}
		if (paused) {
			PauseUI.SetActive (true);
			Time.timeScale = 0;
		}
		if (!paused) {
			PauseUI.SetActive (false);
			Time.timeScale = 1;
		}
	}

	private IEnumerator myCor() {
		yield return new WaitForSeconds (20);
	}

	public void resume () {
		gameObject.GetComponent<AudioSource> ().Play ();
		paused = false;
	}

	public void mainMenu () {
		Time.timeScale = 1;
		GameObject bgm = GameObject.Find ("BackgroundMusicPermanent");
		Destroy (bgm);
		GameObject bgmc = GameObject.Find ("BackgroundMusicPermanent(Clone)");
		Destroy (bgmc);
		gameObject.GetComponent<AudioSource> ().Play ();
		SceneManager.LoadScene ("MainMenu");
	}

	public void quit () {
		gameObject.GetComponent<AudioSource> ().Play ();
		Application.Quit ();
	}
}
