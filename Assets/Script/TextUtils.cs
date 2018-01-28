using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System;

public class TextUtils {
	//private static string textDirectory = "D:\\Unity\\Projectz\\Chinese Dinosaur Whispers Comic\\Assets\\dinosaurText\\";
	private static string textDirectory = "/Users/shali/Desktop/ggj-2018/Assets/dinosaurText/";
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

	public static List<string> GetRandomWords(int count) {
		List<string> result = new List<string> ();
		StreamReader allWordsCSV = new StreamReader (TextUtils.textDirectory + TextUtils.allWordsCSV);
		string allWords = allWordsCSV.ReadToEnd ();
		string[] allWordsArray = allWords.Split (',');
		for (int i = 0; i < count; i++) {
			int index = GetRandomIndex (allWordsArray.Length);
			result.Add (allWordsArray [index]);
		}
		return result;
	}
		
	public static String GetRandomLineOfLength(int wordCount) {
		List<String> appropriateLines = GetLinesOfLength (wordCount);
		return GetRandomLineFromList (appropriateLines);
	}

	private static List<String> GetLinesOfLength(int wordCount) {
		List<String> result = new List<String> ();
		StreamReader linesOfLength = new StreamReader (TextUtils.textDirectory + wordCount + ".txt");
		String line = linesOfLength.ReadLine ();
		while (line != null) {
			result.Add (line);
			line = linesOfLength.ReadLine ();
		}
		return result;
	}

	private static String GetRandomLineFromList (List<String> lines) {
		int index = GetRandomIndex (lines.Count);
		return lines [index];
	}

}
