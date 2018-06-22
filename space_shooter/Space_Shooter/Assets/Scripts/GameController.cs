using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameController : MonoBehaviour {

	public GameObject hazard;
	public Vector3 spawnVals;
	public int hazardCount;

	public float spawnWait;
	public float startWait;
	public float waveWait;

	public Text scoreText;
	public int score;

	void Start () {
		score = 0;
		UpdateScore();
		StartCoroutine (SpawnWaves());
	}

	IEnumerator SpawnWaves () {
		yield return new WaitForSeconds(startWait);
		while(true) {
			for (int i=0; i < hazardCount; i++) {
				Vector3 spawnPos = new Vector3(Random.Range(-spawnVals.x, spawnVals.x),
																			 spawnVals.y,
																			 spawnVals.z);
				Quaternion spawnRot = Quaternion.identity;
				Instantiate (hazard, spawnPos, spawnRot);
				yield return new WaitForSeconds(spawnWait);
			}
			yield return new WaitForSeconds(waveWait);
		}
	}

	public void AddScore(int newScoreValue) {
		score += newScoreValue;
		UpdateScore();
	}

	void UpdateScore () {
		scoreText.text = "Score " + score;
	}
}
