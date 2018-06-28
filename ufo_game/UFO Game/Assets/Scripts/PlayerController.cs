using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour {

	public float speed;
	public Text countText;
	public Text winText;

	public ParticleSystem fireworks;
	public GameObject confettiObject;

	private Rigidbody2D rb;
	private int count;

	void Start() {
		rb = GetComponent<Rigidbody2D>();
		count = 0;
		SetCountText();
		winText.text = "";
	}

	void FixedUpdate() {
		float moveHorizontal = Input.GetAxis("Horizontal");
		float moveVertical = Input.GetAxis("Vertical");
		Vector2 movement = new Vector2(moveHorizontal, moveVertical);
		rb.AddForce(movement * speed);
		transform.Rotate(new Vector3(0,0,-1));
	}

	void OnTriggerEnter2D(Collider2D other) {
		if (other.gameObject.CompareTag("PickUp")) {
			Destroy(other.gameObject);
			count += 1;
			SetCountText();

			if (count >= 12) {
				winText.text = "You Win!";
				fireworks.Play();
				confettiObject.SetActive(true);
			}
		}
	}

	void SetCountText() {
		countText.text = "Count: " + count.ToString();
	}
}
