using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.SceneManagement;

public class ColorPick : MonoBehaviour {

	private Material Tile;
	private Color player_color;
	private Collider clicked;
	private GameObject selector;

	private Settings chosen;

	Ray ray;
	RaycastHit hit;

	// Use this for initialization
	void Start () {
		chosen = GameObject.FindGameObjectWithTag ("GameSettings").GetComponent<Settings> ();
	}

	// Update is called once per frame
	void Update () {
		if (Input.GetMouseButtonDown (0)) {
			ray = Camera.main.ScreenPointToRay(Input.mousePosition);
			if (Physics.Raycast (ray, out hit)) {
				if (hit.collider.gameObject.tag == "Color") {
					player_color = hit.collider.gameObject.GetComponent<Renderer>().material.color;

					if (hit.collider.gameObject.transform.parent.gameObject.tag == "ColorPickP1") {
						chosen.color1_chosen = true;
						Tile = GameObject.FindGameObjectWithTag ("GameSettings").GetComponent<Settings> ().Tile1;
						selector = GameObject.FindGameObjectWithTag ("SelectP1");
						selector.transform.position = new Vector3 (hit.collider.gameObject.transform.position.x, hit.collider.gameObject.transform.position.y, -5);
					} else if (hit.collider.gameObject.transform.parent.gameObject.tag == "ColorPickP2") {
						chosen.color2_chosen = true;
						Tile = GameObject.FindGameObjectWithTag ("GameSettings").GetComponent<Settings> ().Tile2;
						selector = GameObject.FindGameObjectWithTag ("SelectP2");
						selector.transform.position = new Vector3 (hit.collider.gameObject.transform.position.x, hit.collider.gameObject.transform.position.y, -5);
					} 

					Tile.color = player_color;
					Tile.EnableKeyword ("_EMISSION");
					Tile.SetColor ("_EmissionColor", player_color);
					DontDestroyOnLoad (Tile);
				}
			}
		}
	}
}
