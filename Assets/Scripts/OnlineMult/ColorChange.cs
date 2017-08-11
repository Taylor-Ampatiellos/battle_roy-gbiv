using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColorChange : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void OnTriggerEnter2D (Collider2D other) {

		if (other.gameObject.tag == "Player") {
			transform.tag = "p1_point";
			Color col = other.gameObject.GetComponent<MeshRenderer> ().material.color;
			gameObject.GetComponent<Renderer> ().material.color = col;
		}

		if (other.gameObject.name == "Player2") {
			transform.tag = "p2_point";
			//anim.SetInteger ("Color", 2);
		}
	}
}
