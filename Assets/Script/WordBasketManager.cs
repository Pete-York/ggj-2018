﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WordBasketManager : MonoBehaviour {
	private const float minZ = -4.2f;
	private const float maxZ = 4.2f;
	private const float basketX = 6;
	private const float basketY = 0;

	public GameObject wordBasket;

	private List<string> targetSentence;
	private List<GameObject> baskets = new List<GameObject> ();

	void Start () {
		this.targetSentence  = GlobalManager.targetSentence;
		InitialiseBaskets ();
	}

	private void InitialiseBaskets () {
		int count = targetSentence.Count;
		float range = maxZ - minZ;
		float interval = range / count;
		for (int i = 0; i < count; i++) {
			float z = minZ + i * interval;
			InitialiseBasket (z);
		}
	}

	private void InitialiseBasket (float zCoordinate) {
		Vector3 spawnPosition = new Vector3 (basketX, basketY, zCoordinate);
		Quaternion spawnRotation = Quaternion.identity;
		Instantiate (wordBasket, spawnPosition, spawnRotation);
	}
}
