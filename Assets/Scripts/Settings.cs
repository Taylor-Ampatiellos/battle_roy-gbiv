using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.SceneManagement;

public class Settings : MonoBehaviour {

	public Material Tile1;
	public Material Tile2;

	Ray ray;
	RaycastHit hit;

	// Use this for initialization
	void Start () {
		//DontDestroyOnLoad (Tile1);
		//DontDestroyOnLoad (Tile2);
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetMouseButtonDown (0)) {
			ray = Camera.main.ScreenPointToRay(Input.mousePosition);
			if (Physics.Raycast (ray, out hit)) {
				if (hit.collider.gameObject.tag == "Reset") {
					SceneManager.LoadScene (SceneManager.GetActiveScene ().name);
				} if (hit.collider.gameObject.tag == "Menu") {
					SceneManager.LoadScene ("Menu");
				} else if (hit.collider.gameObject.tag == "Start_Local") {
					SceneManager.LoadScene ("Local");
				}
			}
		}

		DontDestroyOnLoad (Tile1);
		DontDestroyOnLoad (Tile2);
	}
}
