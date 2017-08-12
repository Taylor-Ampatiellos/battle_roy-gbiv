using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Powerup_Spawner : MonoBehaviour {

	public int num_powerups;

	public GameObject[] Spawnables;
	private GameObject[] Expand_PUs;

	private BoxCollider2D coll;

	private float x_spawn;
	private float y_spawn;
	private int RandomChoose;
	private int count;

	// Use this for initialization
	void Start () {
		coll = GetComponent<BoxCollider2D>();
		count = 0;
	}
	
	// Update is called once per frame
	void Update () {
		if (count < num_powerups) {
			for (int i = count; i < num_powerups; i++) {
				RandomChoose = Random.Range (0, Spawnables.Length);

				float x_max = coll.bounds.center.x + coll.bounds.extents.x;
				float x_min = coll.bounds.center.x - coll.bounds.extents.x;
				float y_max = coll.bounds.center.y + coll.bounds.extents.y;
				float y_min = coll.bounds.center.y - coll.bounds.extents.y;

				x_spawn = Random.Range (x_max, x_min);
				y_spawn = Random.Range (y_max, y_min);

				Instantiate (Spawnables [RandomChoose], new Vector3 (x_spawn, y_spawn, 0), Quaternion.identity);
				count++;
				Debug.Log (count);
			}
		}
	}

	public void decrease_count () {
		count--;
	}
}
