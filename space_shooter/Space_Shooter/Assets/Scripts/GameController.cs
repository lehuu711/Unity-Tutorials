using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour {

	public GameObject hazard;
	public Vector3 spawnVals;
	public int hazardCount;

	public float spawnWait;
	public float startWait;
	public float waveWait;

	void Start () {
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
}
