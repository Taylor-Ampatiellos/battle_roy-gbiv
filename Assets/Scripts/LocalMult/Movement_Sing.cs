using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement_Sing : MonoBehaviour {

	private Rigidbody2D rb;
	private Powerup_Spawner PU_spawn;
	private CircleCollider2D Bomb;

	public string up;
	public string left;
	public string down;
	public string right;
	public string bomb;
	public float speed;
	public float fallSpeed;
	public float drag;
	public float fallDrag;
	public float getSmaller;

	public Vector2 respawn;

	private int num_bombs;
	private float originalSpeed;
	private float originalDrag;
	private float originalRadius;
	private Vector3 originalScale;

	private bool falling;

	// Set starting variables
	void Start () {
		rb = GetComponent<Rigidbody2D> ();
		rb.drag = drag;
		originalScale = transform.localScale;
		originalSpeed = speed;
		originalDrag = drag;
		falling = false;
		PU_spawn = GameObject.FindGameObjectWithTag ("BoardArea").GetComponent<Powerup_Spawner> ();
		Bomb = transform.GetChild(0).GetComponent<CircleCollider2D> ();
		originalRadius = Bomb.radius;
		num_bombs = 0;
	}
		
	void Update () {

		// Four-way movement
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

		// Respawn upon falling into pit
		if (transform.localScale.x <= 0) {
			falling = false;
			speed = originalSpeed;
			transform.position = respawn;
			transform.localScale = originalScale;
			rb.drag = originalDrag;
		}

		// Falling scale change
		if (falling) {
			transform.localScale -= new Vector3(1, 1, 1) * Time.deltaTime * getSmaller;
		}

		// Bomb
		if (Input.GetKeyDown(bomb)) {
			if (num_bombs > 0) {
				Bomb.radius = 3;
				num_bombs--;
			}
		} else {
			Bomb.radius = originalRadius;
		}
	}

	void OnTriggerStay2D (Collider2D other) {
		// Pick up powerups
		if (other.gameObject.tag == "PU_Expand") {
			transform.localScale += new Vector3 (1, 1, 1) / 5;
			Destroy (other.gameObject);
			StartCoroutine ("Expand_WearOff");
		}

		if (other.gameObject.tag == "PU_Bomb") {
			num_bombs++;
			Destroy (other.gameObject);
			PU_spawn.decrease_count();
		}

		// Detect pits
		if (other.gameObject.tag == "Pit") {
			if (Bomb.radius == originalRadius) {
				falling = true;
				rb.drag = fallDrag;
				speed = fallSpeed;
			}
		}
	}

	// Powerup wear off
	IEnumerator Expand_WearOff () {
		yield return new WaitForSeconds (5);
		transform.localScale = originalScale;
		PU_spawn.decrease_count();
	}
}
