using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using UnityEngine;
using System;

public class TextUtils : MonoBehaviour {
	private static string textDirectory = "D:\\Unity\\Projectz\\Chinese Dinosaur Whispers Comic\\Assets\\dinosaurText\\";
	private static string dinoXml = "everywordindinosaurcomicsOHGOD.xml";
	private static string allWordsCSV = "all-words.csv";

	public static string GetRandomWord() {
		StreamReader allWordsCSV = new StreamReader (TextUtils.textDirectory + TextUtils.allWordsCSV);
		string allWords = allWordsCSV.ReadToEnd ();
		string[] allWordsArray = allWords.Split (',');
		int index = GetRandomIndex (allWordsArray.Length);
		return allWordsArray [index];
	}

	private static int GetRandomIndex (int max) {
		System.Random random = new System.Random ();
		double index = (random.NextDouble () * (double) max);
		return (int) Math.Floor (index);
	}
}
