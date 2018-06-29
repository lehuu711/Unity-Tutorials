using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectScroller : MonoBehaviour
{
	private Rigidbody2D rb;

	// Use this for initialization
	void Start ()
	{
		//Get and store a reference to the Rigidbody2D attached to this GameObject.
		rb = GetComponent<Rigidbody2D>();

		//Start the object moving.
		rb.velocity = new Vector2 (GameController.instance.scrollSpeed, 0) *
									Vector2.left;
	}

	void Update()
	{
		// If the game is over, stop scrolling.
		if(GameController.instance.gameOver == true)
		{
			rb.velocity = Vector2.zero;
		}
	}
}
