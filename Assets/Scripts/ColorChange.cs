using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColorChange : MonoBehaviour {

	Animator anim;

	// Use this for initialization
	void Start () {
		anim = GetComponent<Animator> ();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void OnTriggerEnter2D (Collider2D other) {

		Debug.Log ("HERE");

		if (other.gameObject.name == "Player1") {
			anim.SetInteger ("Color", 1);
		}

		if (other.gameObject.name == "Player2") {
			anim.SetInteger ("Color", 2);
		}
	}
}
