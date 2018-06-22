using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour {

	public GameObject hazard;
	public Vector3 spawnVals;

	void Start () {
		SpawnWaves ();
	}

	void SpawnWaves () {
		Vector3 spawnPos = new Vector3(Random.Range(-spawnVals.x, spawnVals.x), spawnVals.y, spawnVals.z);
		Quaternion spawnRot = Quaternion.identity;
		Instantiate (hazard, spawnPos, spawnRot);
	}
}
