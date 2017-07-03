using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Powerup_Spawner : MonoBehaviour {

	public Transform Expand_PU;
	public int num_Expand_PUs;
	private GameObject[] Expand_PUs;

	private BoxCollider2D coll;

	private float x_spawn;
	private float y_spawn;

	// Use this for initialization
	void Start () {
		coll = GetComponent<BoxCollider2D>();
		for (int i = 0; i < num_Expand_PUs; i++) {
			add_Expand_PU();
		}
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void add_Expand_PU () {
		float x_max = coll.bounds.center.x + coll.bounds.extents.x;
		float x_min = coll.bounds.center.x - coll.bounds.extents.x;
		float y_max = coll.bounds.center.y + coll.bounds.extents.y;
		float y_min = coll.bounds.center.y - coll.bounds.extents.y;

		x_spawn = Random.Range (x_max, x_min);
		y_spawn = Random.Range (y_max, y_min);

		Instantiate (Expand_PU, new Vector3 (x_spawn, y_spawn, 0), Quaternion.identity);
	}
}
