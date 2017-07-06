using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Color_Player1 : MonoBehaviour {

	public Material Tile1;
	private Color player_color;
	private Collider clicked;

	Ray ray;
	RaycastHit hit;

	// Use this for initialization
	void Start () {
		
	}

	// Update is called once per frame
	void Update () {
		if (Input.GetMouseButtonDown (0)) {
			ray = Camera.main.ScreenPointToRay(Input.mousePosition);
			if (Physics.Raycast (ray, out hit)) {
				if (hit.collider.gameObject.tag == "Color_Red") {
					player_color = Color.red;
					Debug.Log ("1");
				} else if (hit.collider.gameObject.tag == "Color_Blue") {
					player_color = Color.blue;
					Debug.Log ("2");
				} else if (hit.collider.gameObject.tag == "Color_Green") {
					player_color = Color.green;
					Debug.Log ("3");
				}
			}

			Tile1.color = player_color;
			Tile1.EnableKeyword ("_EMISSION");
			Tile1.SetColor ("_EmissionColor", player_color);
		
		}
	}
}
