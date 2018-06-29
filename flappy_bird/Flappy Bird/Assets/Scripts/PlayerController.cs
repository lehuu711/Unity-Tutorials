using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {

	public float upForce;

	private bool isDead;
	private Rigidbody2D rb;
	private Animator anim;

	void Start() {
		isDead = false;
		rb = GetComponent<Rigidbody2D>();
		anim = GetComponent<Animator>();
	}

	void Update() {
		// Hop if not yet and left-click triggered
		if (!isDead && Input.GetMouseButtonDown(0)) {
			// Resets velocity and hops up
			rb.velocity = new Vector2(0,upForce);
			anim.SetTrigger("Flap");
		}
	}

	void FixedUpdate() {
		// Clamp the player to the edge of screen and reset movement
		if (rb.position.y >= Camera.main.orthographicSize - 0.25f) {
			rb.position = new Vector2(0,Camera.main.orthographicSize - 0.25f);
			rb.velocity = Vector2.zero;
		}
	}

	// Player dies if they collide into anything
	void OnCollisionEnter2D(Collision2D col) {
		anim.SetTrigger("Die");
		rb.velocity = Vector2.zero;
		isDead = true;
		GameController.instance.GameOver();
	}
}
