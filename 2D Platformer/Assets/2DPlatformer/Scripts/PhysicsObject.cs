using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PhysicsObject : MonoBehaviour {

	public float gravityMod = 3f;

	protected Vector2 velocity;
	protected Rigidbody2D rb;

	void OnEnable() {
		rb = GetComponent<Rigidbody2D>();
	}

	void FixedUpdate() {
		velocity += gravityMod * Physics2D.gravity * Time.deltaTime;

		Vector2 deltaPos = velocity * Time.deltaTime;

		Vector2 move = Vector2.up * deltaPos.y;

		Movement(move);
	}

	void Movement(Vector2 move) {
		rb.position = rb.position + move;
	}
}
