using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BGScroller : MonoBehaviour {

	public float tileSize;

	private Vector2 startPosition;
	private float startTime;


	// Use this for initialization
	void Start () {
		startPosition = Vector2.zero;
		startTime = Time.time;
	}


	// Update is called once per frame
	void Update () {
		if (GameController.instance.gameOver) {
			// Do nothing
		} else {
			float newPosition = Mathf.Repeat((Time.time-startTime) *
																			 GameController.instance.scrollSpeed,
																			 tileSize);
			transform.position = startPosition + Vector2.left * newPosition;
		}
	}
}
