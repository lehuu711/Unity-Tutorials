using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour {

	public static GameController instance;

	public Text scoreText;
	public GameObject gameOverText;
	public float scrollSpeed = 1.5f;
	public bool gameOver;

	private int score;

	void Awake() {
		if (instance == null) {
			instance = this;
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

	public void AddScore() {
		score++;
		scoreText.text = "Score: " + score.ToString();
	}

	public void GameOver() {
		gameOverText.SetActive(true);
		gameOver = true;
	}
}
