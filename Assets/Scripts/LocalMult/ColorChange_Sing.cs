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

		//Tile1.color = GameObject.FindGameObjectWithTag ("Player1").GetComponent<MeshRenderer> ().material.color;
		//Tile1.EnableKeyword ("_EMISSION");
		//Tile1.SetColor ("_EmissionColor", GameObject.FindGameObjectWithTag ("Player1").GetComponent<MeshRenderer> ().material.color);

		//Tile2.color = GameObject.FindGameObjectWithTag ("Player2").GetComponent<MeshRenderer> ().material.color;
		//Tile2.EnableKeyword ("_EMISSION");
		//Tile2.SetColor ("_EmissionColor", GameObject.FindGameObjectWithTag ("Player2").GetComponent<MeshRenderer> ().material.color);
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void OnTriggerEnter2D (Collider2D other) {
		
		if (other.gameObject.name == "Player1") {
			transform.tag = "p1_point";
			gameObject.GetComponent<Renderer> ().material = Tile1;
		}

		if (other.gameObject.name == "Player2") {
			transform.tag = "p2_point";
			gameObject.GetComponent<Renderer> ().material = Tile2;
		}
	}
}
