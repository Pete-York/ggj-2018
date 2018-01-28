using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class WordBasketManager : MonoBehaviour {
	private const string nextPlayerSceneName = "NextPlayer";
	private const string FinalScoreSceneName = "FinalScoreScreen";
	private const float minZ = -3.8f;
	private const float maxZ = 3.2f;
	private const float basketX = 6;
	private const float basketY = 0;

	public GameObject wordBasket;

	private List<string> targetSentence;
	private List<GameObject> baskets = new List<GameObject> ();

	void Start () {
		this.targetSentence  = GlobalManager.originalTargetSentence;
		InitialiseBaskets ();
	}

	private void InitialiseBaskets () {
		int count = targetSentence.Count;
		float range = maxZ - minZ;
		float interval = range / Mathf.Max(count - 1, 1);
		for (int i = 0; i < count; i++) {
			float z = minZ + i * interval;
			InitialiseBasket (z);
		}
	}

	private void InitialiseBasket (float zCoordinate) {
		Vector3 spawnPosition = new Vector3 (basketX, basketY, zCoordinate);
		Quaternion spawnRotation = Quaternion.identity;
		baskets.Add (Instantiate (wordBasket, spawnPosition, spawnRotation));
	}

	public void MoveToNextPlayerScene () {
		List<string> newTargetSentence = GetNewTargetSentence ();
		GlobalManager.currentTargetSentence = newTargetSentence;
		if (GlobalManager.currentPlayer < GlobalManager.numberOfPlayers) {
			GlobalManager.currentPlayer++;
			SceneManager.LoadScene (nextPlayerSceneName);
		} else {
			SceneManager.LoadScene (FinalScoreSceneName);
		}
	}

	private List<string> GetNewTargetSentence () {
		List<string> result = new List<string> ();
		for (int i = baskets.Count - 1; i >= 0; i--) {
			FinalWordBasket finalWordBasket = baskets[i].GetComponent<FinalWordBasket> ();
			result.Add (finalWordBasket.getWord ());
		}
		return result;
	}
}
