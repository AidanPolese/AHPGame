using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class swordHitBoxprefab : MonoBehaviour {
	public GameObject swordHitBoxPrefab;
	GameObject swordHitBoxPrefabClone;

	void Update(){
		if (Input.GetKeyDown (KeyCode.F)) {
			swordHitBoxPrefabClone = Instantiate (swordHitBoxPrefab, transform.position, Quaternion.identity) as GameObject;
			Destroy (swordHitBoxPrefabClone, 2); //2 is how long the clone is alive for.
		}
	}
}
