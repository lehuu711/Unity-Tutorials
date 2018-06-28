using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BGScroller : MonoBehaviour {

	public float tileSize;

	private Vector2 startPosition;


	// Use this for initialization
	void Start () {
		startPosition = transform.position;
	}


	// Update is called once per frame
	void Update () {
		if (GameController.instance.gameOver) {
			// Do nothing
		} else {
			float newPosition = Mathf.Repeat(Time.time *
																			 GameController.instance.scrollSpeed,
																			 tileSize);
			transform.position = startPosition + Vector2.right * newPosition;
		}
	}
}
