using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour {

	public int walkspeed;
	private Rigidbody2D rb;

	public string up;
	public string left;
	public string down;
	public string right;

	public float FallSpeed;
	public Vector2 respawn;
	private Vector3 originalScale;
	private int originalSpeed;

	// Use this for initialization
	void Start () {
		rb = GetComponent<Rigidbody2D> ();
		originalScale = transform.localScale;
		originalSpeed = walkspeed;
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKey(up)) {
			rb.AddForce (transform.up * walkspeed);
		}

		if (Input.GetKey(left)) {
			rb.AddForce (Vector2.left * walkspeed);
		}

		if (Input.GetKey(down)) {
			rb.AddForce (Vector2.down * walkspeed);
		}
			
		if (Input.GetKey (right)) {
			rb.AddForce (Vector2.right * walkspeed);
		}

		if (transform.localScale.x <= 0) {
			walkspeed = originalSpeed;
			transform.position = respawn;
			transform.localScale = originalScale;

		}
	}

	void OnTriggerStay2D (Collider2D other) {
		if (other.gameObject.tag == "Pit" && transform.localScale.x > 0) {
			walkspeed = 1;
			transform.localScale -= new Vector3(1, 1, 1) * Time.deltaTime * FallSpeed;
		}
	}
}
