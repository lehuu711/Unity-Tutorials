using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColumnPooler : MonoBehaviour {

	public int poolSize = 5;
	public float spawnRate = 4f;
	public GameObject columnPrefab;
	public Vector2 columnRange;

	private GameObject[] columns;
	private Vector2 poolPos;
	private float timeSinceLastSpawn;
	private float spawnXPos = 10f;
	private int columnI = 0;

	// Use this for initialization
	void Start () {
		poolPos = new Vector2(-15f, -25f);
		columns = new GameObject[poolSize];
		for (int i = 0; i < poolSize; i++) {
			columns[i] = (GameObject) Instantiate(columnPrefab,
																						poolPos,
																						Quaternion.identity);
		}
	}

	// Update is called once per frame
	void Update () {
		timeSinceLastSpawn += Time.deltaTime;
		if (!GameController.instance.gameOver && timeSinceLastSpawn >= spawnRate) {
			timeSinceLastSpawn = 0;
			float spawnYPos = Random.Range(columnRange.x,columnRange.y);
			columns[columnI].transform.position = new Vector2(spawnXPos,spawnYPos);
			columnI = (columnI + 1) % poolSize;
		}
	}
}
