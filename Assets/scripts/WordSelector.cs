using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using System;

public class WordSelector : MonoBehaviour {
	private static string allWordsFile = "D:\\Unity\\Projectz\\Chinese Dinosaur Whispers Comic\\Assets\\dinosaurText\\all-words.csv";
	private StreamReader  allWordsCSV;

	void Start () {
		allWordsCSV = new StreamReader (allWordsFile);
	}

	void Update () {
			
	}

	private string GetRandomWord() {
		string allWords = allWordsCSV.ReadToEnd ();
		string[] allWordsArray = allWords.Split (',');
		int index = GetRandomIndex (allWordsArray.Length);
		return allWordsArray [index];
	}

	private int GetRandomIndex (int max) {
		System.Random random = new System.Random ();
		double index = (random.NextDouble () * (double) max);
		return (int) Math.Floor (index);
	}
}
