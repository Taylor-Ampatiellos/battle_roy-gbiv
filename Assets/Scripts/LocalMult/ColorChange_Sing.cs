using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColorChange_Sing : MonoBehaviour {

	private Material Tile1;
	private Material Tile2;

	// Use this for initialization
	void Start () {
		Tile1 = GameObject.FindGameObjectWithTag ("GameSettings").GetComponent<Settings>().Tile1;
		Tile2 = GameObject.FindGameObjectWithTag ("GameSettings").GetComponent<Settings>().Tile2;
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void OnTriggerEnter2D (Collider2D other) {
		if (other.gameObject.tag == "Player1") {
			transform.tag = "p1_point";
			gameObject.GetComponent<Renderer> ().material = Tile1;
		}

		if (other.gameObject.tag == "Player2") {
			transform.tag = "p2_point";
			gameObject.GetComponent<Renderer> ().material = Tile2;
		}
	}
}
