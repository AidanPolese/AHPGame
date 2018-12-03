using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EndLevelScript : MonoBehaviour {

	public GUIText endLevelText;
	public string nextLevel;

	bool hasEnded;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if (hasEnded /*&& Input.GetKeyDown(KeyCode.Space)*/) {
			SceneManager.LoadScene (nextLevel);
		}
	}

	void OnTriggerEnter2D(Collider2D other) {
		if (other.tag == "Player") {
			//endLevelText.gameObject.SetActive (true);
			hasEnded = true;
		}
	}
}
