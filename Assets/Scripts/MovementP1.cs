using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementP1 : MonoBehaviour {

	public int walkspeed;
	public int runspeed;
	public Rigidbody2D rb;

	// Use this for initialization
	void Start () {
		rb = GetComponent<Rigidbody2D> ();
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKey("w")) {
			if (Input.GetKey (KeyCode.LeftShift)) {
				rb.AddForce (transform.up * runspeed); 
			} else {
				rb.AddForce (transform.up * walkspeed);
			}
		}

		if (Input.GetKey("a")) {
			if (Input.GetKey (KeyCode.LeftShift)) {
				rb.AddForce (Vector2.left * runspeed); 
			} else {
				rb.AddForce (Vector2.left * walkspeed);
			}
		}

		if (Input.GetKey("s")) {
			if (Input.GetKey (KeyCode.LeftShift)) {
				rb.AddForce (Vector2.down * runspeed); 
			} else {
				rb.AddForce (Vector2.down * walkspeed);
			}
		}
			
		if (Input.GetKey ("d")) {
			if (Input.GetKey (KeyCode.LeftShift)) {
				rb.AddForce (Vector2.right * runspeed); 
			} else {
				rb.AddForce (Vector2.right * walkspeed);
			}
		}
	}
}
