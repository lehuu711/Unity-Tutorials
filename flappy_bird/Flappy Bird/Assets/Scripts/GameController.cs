using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour {

	public static GameController instance;

	public GameObject gameOverText;
	public float scrollSpeed;
	public bool gameOver;

	void Awake() {
		if (instance == null) {
			instance = this;
			scrollSpeed = -1.5f;
			gameOver = false;
		} else {
			Destroy(gameObject);
		}
	}

	void Update () {
		if (gameOver && Input.GetMouseButtonDown(0)) {
			SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
		}
	}

	public void GameOver() {
		gameOverText.SetActive(true);
		gameOver = true;
	}
}
