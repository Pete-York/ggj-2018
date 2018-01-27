using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class generateBlocks : MonoBehaviour {

	public GameObject block;

	private float blockPos_x = -6.0f;
	private float blockPos_y = 0.0f;
	private float blockPos_z = 4.2f;
	private int blockCount = 5;
	private float spawnWait = 1.0f;
	private float startWait = 0.5f;
	private float waveWait = 2.0f;

	void Start () {

		StartCoroutine (SpawnWaves ());
		
	}

	IEnumerator SpawnWaves ()
	{
		yield return new WaitForSeconds (startWait);
		while (true) 
		{
			for (int i = 0; i < blockCount; i++) 
			{
				Vector3 spawnPosition = new Vector3 (blockPos_x, blockPos_y, Random.Range (-1.0f, 1.0f) * blockPos_z);
				Quaternion spawnRotation = Quaternion.identity;
				blocksController blockController = Instantiate (block, spawnPosition, spawnRotation).GetComponent<blocksController> ();
				InitialiseBlock (blockController);
				yield return new WaitForSeconds (spawnWait);
			}
			yield return new WaitForSeconds (waveWait);
		}
	}


	private void InitialiseBlock(blocksController blockController) {
		blockController.SetWord (TextUtils.GetRandomWord());
	}
}
