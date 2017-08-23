using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.SceneManagement;

public class Settings : MonoBehaviour {

	public Material Tile1;
	public Material Tile2;

	public Transform start;

	public bool color1_chosen = false;
	public bool color2_chosen = false;

	private bool start_spawned = false;

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
				} else if (hit.collider.gameObject.tag == "Menu") {
					SceneManager.LoadScene ("Menu");
				} else if (hit.collider.gameObject.tag == "Start_Local") {
					SceneManager.LoadScene ("Local");
				}
			}
		}

		if (color1_chosen && color2_chosen && !(start_spawned)) {
			Instantiate (start, new Vector3 (3.5f, 0, 0), Quaternion.identity);
			start_spawned = true;
		}

		DontDestroyOnLoad (Tile1);
		DontDestroyOnLoad (Tile2);
	}
}
