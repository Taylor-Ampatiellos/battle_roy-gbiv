using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.Networking;

public class Movement : NetworkBehaviour {

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

	private bool falling;

	public Color LocalPlayerColor;

	// Use this for initialization
	void Start () {
		rb = GetComponent<Rigidbody2D> ();
		rb.drag = drag;
		originalScale = transform.localScale;
		originalSpeed = speed;
		originalDrag = drag;
		falling = false;
	}

	public override void OnStartLocalPlayer () {
		gameObject.GetComponent<MeshRenderer> ().material.color = LocalPlayerColor;
	}

	// Update is called once per frame
	void Update () {
		if (!isLocalPlayer) {
			return;
		}

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
			falling = false;
			speed = originalSpeed;
			transform.position = respawn;
			transform.localScale = originalScale;
			rb.drag = originalDrag;
		}

		if (falling) {
			transform.localScale -= new Vector3(1, 1, 1) * Time.deltaTime * getSmaller;
		}
	}

	void OnTriggerEnter2D (Collider2D other) {
		if (other.gameObject.tag == "PU_Expand") {
			transform.localScale += new Vector3 (1, 1, 1) / 5;
			Destroy (other.gameObject);
			StartCoroutine ("Expand_WearOff");
		}

		if (other.gameObject.tag == "Pit") {
			falling = true;
			rb.drag = fallDrag;
			speed = fallSpeed;
		}
	}

	IEnumerator Expand_WearOff () {
		yield return new WaitForSeconds (5);
		transform.localScale = originalScale;
	}
}
