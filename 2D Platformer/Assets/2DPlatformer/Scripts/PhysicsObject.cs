using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PhysicsObject : MonoBehaviour {

	public float minGroundNormY = 0.65f;
	public float gravityMod = 1.0f;

	protected Vector2 targetVelocity;
	protected bool grounded;
	protected Vector2 groundNorm;

	protected Rigidbody2D rb;
	protected Vector2 velocity;
	protected ContactFilter2D contactFilter;
	protected RaycastHit2D[] hitBuffer = new RaycastHit2D[16];
	protected List<RaycastHit2D> hitBufferL = new List<RaycastHit2D>(16);

	protected const float minMoveDist = 0.001f;
	protected const float shellRadius = 0.01f; // Extra padding

	void OnEnable() {
		rb = GetComponent<Rigidbody2D>();
	}

	void Start() {
		// Set contact filer to only check raycast collisions on gameobjects
		contactFilter.useTriggers = false;
		contactFilter.SetLayerMask(Physics2D.GetLayerCollisionMask(gameObject.layer));
		contactFilter.useLayerMask = true;
	}

	void FixedUpdate() {
		velocity += gravityMod * Physics2D.gravity * Time.deltaTime;
		velocity.x = targetVelocity.x;

		grounded = false; // Assume not grounded until we check for it in movement

		Vector2 deltaPos = velocity * Time.deltaTime;
		Vector2 moveAlongGround = new Vector2(groundNorm.y,-groundNorm.x);

		// Calculate x movement first (works for slopes)
		Vector2 move = moveAlongGround * deltaPos.x;
		Movement(move,false);

		// Calculate y movement
		move = Vector2.up * deltaPos.y;
		Movement(move, true);
	}

	void Movement(Vector2 move, bool yMovement) {
		// Modify movement if it's greater than minimum movement.
		float dist = move.magnitude;
		if  (dist > minMoveDist) {
			// Cast our rb into a move and grab all collisions
			int count = rb.Cast(move, contactFilter, hitBuffer, dist + shellRadius);
			hitBufferL.Clear();
			for (int i = 0; i < count; i++) {
				hitBufferL.Add(hitBuffer[i]);
			}

			// Check if this object is grounded / angled on another collider
			for (int i = 0; i < hitBufferL.Count; i++) {
				Vector2 currNorm = hitBufferL[i].normal;
				if (currNorm.y > minGroundNormY) {
					grounded = true;
					if (yMovement) {
						groundNorm = currNorm;
						currNorm.x = 0;
					}
				}

				// Alter velocity based on collision
				float projection = Vector2.Dot(velocity,currNorm);
				if (projection < 0) {
					velocity = velocity - projection * currNorm;
				}

				// Prevent getting stuck into other colliders
				float modifiedDist = hitBufferL[i].distance - shellRadius;
				dist = modifiedDist < dist ? modifiedDist : dist;
			}
		}
		rb.position = rb.position + move.normalized * dist;
	}
}
