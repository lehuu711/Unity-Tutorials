using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AutoMoveCrate : PhysicsObject {

	// Update is called once per frame
	void Update () {
		targetVelocity = Vector2.left;
	}
}
