using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour {

	public static GameController instance;

	public GameObject gameOverText;
	public bool gameOver;

	void Awake() {
		if (instance == null) {
			instance = this;
		}
		else {
			Destroy(gameObject);
		}
	}

	void Start() {
		gameOver = false;
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
