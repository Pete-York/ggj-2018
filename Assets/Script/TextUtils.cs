using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System;

public class TextUtils {
	private static string allWordsCSV = "all-words";
	public static TextAsset allWords;
	public static TextAsset oneLengthSentence;

	public static string GetRandomWord() {
		TextAsset allWordsCSV = Resources.Load(TextUtils.allWordsCSV, typeof(TextAsset)) as TextAsset;

		string allWords = allWordsCSV.text;
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
		TextAsset allWordsCSV = Resources.Load(TextUtils.allWordsCSV, typeof(TextAsset)) as TextAsset;
		string allWords = allWordsCSV.text;
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
		TextAsset linesOfLengthFile = Resources.Load(wordCount.ToString(), typeof(TextAsset)) as TextAsset;
		string linesOfLength = linesOfLengthFile.text;
		string[] linesOfLengthStrings = linesOfLength.Split('\n');
		foreach (string line in linesOfLengthStrings) {
			result.Add (line);
		}
		return result;
	}

	private static String GetRandomLineFromList (List<String> lines) {
		int index = GetRandomIndex (lines.Count);
		return lines [index];
	}


	public static string GetSentenceString (List<string> sentence) {
		string result = "";
		foreach (string word in sentence) {
			result += " " + word;
		}
		return result;
	}
}
