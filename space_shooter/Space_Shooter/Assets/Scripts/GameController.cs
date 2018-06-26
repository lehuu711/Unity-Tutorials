using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour {

	public GameObject[] hazards;
	public Vector3 spawnVals;
	public int hazardCount;

	public float spawnWait;
	public float startWait;
	public float waveWait;

	public Text scoreText;
	public Text restartText;
	public Text gameOverText;

	private int score;
	private bool gameOver;
	private bool restart;

	void Start () {
		score = 0;
		UpdateScore();

		restart = false;
		gameOver = false;
		restartText.text = "";
		gameOverText.text = "";

		StartCoroutine (SpawnWaves());
	}

	void Update() {
		if (restart) {
			if (Input.GetKeyDown(KeyCode.R)) {
				SceneManager.LoadScene("Main");
			}
		}
	}

	IEnumerator SpawnWaves () {
		yield return new WaitForSeconds(startWait);
		while(true) {
			for (int i=0; i < hazardCount; i++) {
				GameObject hazard = hazards[Random.Range(0,hazards.Length)];
				Vector3 spawnPos = new Vector3(Random.Range(-spawnVals.x, spawnVals.x),
																			 spawnVals.y,
																			 spawnVals.z);
				Quaternion spawnRot = Quaternion.identity;
				Instantiate (hazard, spawnPos, spawnRot);
				yield return new WaitForSeconds(spawnWait);
			}
			yield return new WaitForSeconds(waveWait);

			if (gameOver) {
				restartText.text = "Press 'R' to restart.";
				restart = true;
				break;
			}
		}
	}

	public void AddScore(int newScoreValue) {
		score += newScoreValue;
		UpdateScore();
	}

	void UpdateScore () {
		scoreText.text = "Score " + score;
	}

	public void GameOver() {
		gameOverText.text = "Game Over!";
		gameOver = true;
	}
}
