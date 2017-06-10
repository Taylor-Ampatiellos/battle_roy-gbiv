using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour {

	public int walkspeed;
	public int runspeed;
	private Rigidbody2D rb;

	public string up;
	public string left;
	public string down;
	public string right;

	public float FallSpeed;
	public Vector2 respawn;
	private Vector3 originalScale;

	// Use this for initialization
	void Start () {
		rb = GetComponent<Rigidbody2D> ();
		originalScale = transform.localScale;
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKey(up)) {
			if (Input.GetKey (KeyCode.LeftShift)) {
				rb.AddForce (transform.up * runspeed); 
			} else {
				rb.AddForce (transform.up * walkspeed);
			}
		}

		if (Input.GetKey(left)) {
			if (Input.GetKey (KeyCode.LeftShift)) {
				rb.AddForce (Vector2.left * runspeed); 
			} else {
				rb.AddForce (Vector2.left * walkspeed);
			}
		}

		if (Input.GetKey(down)) {
			if (Input.GetKey (KeyCode.LeftShift)) {
				rb.AddForce (Vector2.down * runspeed); 
			} else {
				rb.AddForce (Vector2.down * walkspeed);
			}
		}
			
		if (Input.GetKey (right)) {
			if (Input.GetKey (KeyCode.LeftShift)) {
				rb.AddForce (Vector2.right * runspeed); 
			} else {
				rb.AddForce (Vector2.right * walkspeed);
			}
		}

		if (transform.localScale.x <= 0) {
			transform.position = respawn;
			transform.localScale = originalScale;

		}
	}

	void OnTriggerStay2D (Collider2D other) {
		if (other.gameObject.tag == "Pit" && transform.localScale.x > 0) {
			transform.localScale -= new Vector3(1, 1, 1) * Time.deltaTime * FallSpeed;
		}
	}
}
