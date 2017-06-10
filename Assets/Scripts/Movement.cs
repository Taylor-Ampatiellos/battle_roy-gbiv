using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour {

	private Rigidbody2D rb;

	public string up;
	public string left;
	public string down;
	public string right;
	public float speed;
	public float fallSpeed;
	public float drag;
	public float fallDrag;
	public float getSmaller;

	public Vector2 respawn;

	private float originalSpeed;
	private float originalDrag;
	private Vector3 originalScale;

	// Use this for initialization
	void Start () {
		rb = GetComponent<Rigidbody2D> ();
		rb.drag = drag;
		originalScale = transform.localScale;
		originalSpeed = speed;
		originalDrag = drag;
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKey(up)) {
			rb.AddForce (transform.up * speed);
		}

		if (Input.GetKey(left)) {
			rb.AddForce (Vector2.left * speed);
		}

		if (Input.GetKey(down)) {
			rb.AddForce (Vector2.down * speed);
		}
			
		if (Input.GetKey (right)) {
			rb.AddForce (Vector2.right * speed);
		}

		if (transform.localScale.x <= 0) {
			speed = originalSpeed;
			transform.position = respawn;
			transform.localScale = originalScale;
			rb.drag = originalDrag;
		}
	}

	void OnTriggerStay2D (Collider2D other) {
		if (other.gameObject.tag == "Pit" && transform.localScale.x > 0) {
			rb.drag = fallDrag;
			speed = fallSpeed;
			transform.localScale -= new Vector3(1, 1, 1) * Time.deltaTime * getSmaller;
		}
	}
}
