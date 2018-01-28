using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class generateBlocks : MonoBehaviour {

	public GameObject block;

	private const int wordListLength = 25;
	private float blockPos_x = -6.0f;
	private float blockPos_y = 0.0f;
	private float blockPos_z = 4.2f;
	private int blockCount = 5;
	private float spawnWait = 1.0f;
	private float startWait = 0.5f;
	private float waveWait = 2.0f;

	void Start () {
		List<string> wordList = WordListGenerator.GetWordList(GlobalManager.targetSentence, wordListLength);
		StartCoroutine (SpawnWaves (wordList));
	}

	IEnumerator SpawnWaves (List<string> wordList)
	{
		yield return new WaitForSeconds (startWait);
		while (wordList.Count > 0) 
		{
			for (int i = 0; i < blockCount; i++) 
			{
				Vector3 spawnPosition = new Vector3 (blockPos_x, blockPos_y, Random.Range (-1.0f, 1.0f) * blockPos_z);
				Quaternion spawnRotation = Quaternion.identity;
				blocksController blockController = Instantiate (block, spawnPosition, spawnRotation).GetComponent<blocksController> ();
				InitialiseBlock (blockController, wordList);
				yield return new WaitForSeconds (spawnWait);
			}
			yield return new WaitForSeconds (waveWait);
		}
	}


	private void InitialiseBlock(blocksController blockController, List<string> wordList) {
		blockController.SetWord (wordList[0]);
		wordList.RemoveAt(0);
	}
}
