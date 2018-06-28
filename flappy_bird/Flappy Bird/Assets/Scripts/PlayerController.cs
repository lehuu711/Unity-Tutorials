using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {

	public float upForce;

	private Rigidbody2D rb;
	private bool isDead;

	void Start() {
		isDead = false;
		rb = GetComponent<Rigidbody2D>();
	}

	// Update is called once per frame
	void Update() {
		// Hop if not yet and left-click triggered
		if (!isDead) {
			if (Input.GetMouseButtonDown(0)) {
				// Resets velocity and hops up
				rb.velocity = new Vector2(0,upForce);
			}
		}
	}

	// Player dies if they collide into anything
	void OnCollisionEnter2D(Collision2D col) {
		isDead = true;
	}
}
