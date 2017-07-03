using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement_Sing : MonoBehaviour {

	private Rigidbody2D rb;
	private Powerup_Spawner PU_spawn;

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

	// Use this for initialization
	void Start () {
		rb = GetComponent<Rigidbody2D> ();
		rb.drag = drag;
		originalScale = transform.localScale;
		originalSpeed = speed;
		originalDrag = drag;
		falling = false;
		PU_spawn = GameObject.FindGameObjectWithTag ("BoardArea").GetComponent<Powerup_Spawner> ();
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
		PU_spawn.add_Expand_PU();
	}
}
