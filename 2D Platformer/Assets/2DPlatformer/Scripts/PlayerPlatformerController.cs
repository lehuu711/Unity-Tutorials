using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerPlatformerController : PhysicsObject {

	public float maxSpeed = 7;
	public float jumpTakeOff = 7;

	// Use this for initialization
	void Start () {

	}

	// Update is called once per frame
	protected override void ComputeVelocity() {
		Vector2 move = Vector2.zero;

		move.x = Input.GetAxis("Horizontal");

		// Let the player jump if grounded and Jump button pressed
		if (Input.GetButtonDown("Jump") && grounded) {
			velocity.y = jumpTakeOff;
		}
		// Stops the jump velocity if player releases Jump button midair
		else if (Input.GetButtonUp("Jump")) {
			if (velocity.y > 0) {
				velocity.y = velocity.y * 0.5f;
			}
		}

		targetVelocity = move * maxSpeed;
	}
}
