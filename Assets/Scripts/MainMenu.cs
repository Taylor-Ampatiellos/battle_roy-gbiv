using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour {

	public Transform start;

	// Use this for initialization
	void Start () {
		Instantiate(start, new Vector3(4.5f, 0, 0), Quaternion.identity);
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
