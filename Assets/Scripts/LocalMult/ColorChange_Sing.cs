using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColorChange_Sing : MonoBehaviour {

	Animator anim;

	// Use this for initialization
	void Start () {
		anim = GetComponent<Animator> ();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void OnTriggerEnter2D (Collider2D other) {

		if (other.gameObject.name == "Player1") {
			transform.tag = "p1_point";
			anim.SetInteger ("Color", 1);
		}

		if (other.gameObject.name == "Player2") {
			transform.tag = "p2_point";
			anim.SetInteger ("Color", 2);
		}
	}
}
