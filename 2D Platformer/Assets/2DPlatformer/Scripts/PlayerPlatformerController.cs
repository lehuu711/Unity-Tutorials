using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerPlatformerController : PhysicsObject {

	public float maxSpeed = 7;
	public float jumpTakeOff = 7;

	private SpriteRenderer spriteRenderer;
	private Animator animator;

	// Use this for initialization
	void Awake () {
		spriteRenderer = GetComponent<SpriteRenderer>();
		animator = GetComponent<Animator>();
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

		// Flip the sprite if the x direction has changed.
		bool flipSprite = (spriteRenderer.flipX ? (move.x > 0.01f) : (move.x < 0.01f));
		if (flipSprite) {
			spriteRenderer.flipX = !spriteRenderer.flipX;
		}

		animator.SetBool("grounded", grounded);
		animator.SetFloat("velocityX", Mathf.Abs(velocity.x)/maxSpeed);

		targetVelocity = move * maxSpeed;
	}
}
