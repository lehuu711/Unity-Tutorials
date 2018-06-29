using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColumnController : MonoBehaviour {

	void OnTriggerEnter2D(Collider2D other) {
		if (other.GetComponent<PlayerController>() != null) {
			GameController.instance.AddScore();
		}
	}
}
