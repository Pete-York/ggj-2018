using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class WordListGenerator {
	public static List<string> GetWordList (int wordListLength) {
		List<string> wordList = new List<string> ();
		List<string> requiredWords = GetRequiredWords ();
		wordList.AddRange (requiredWords);
		AddRandomWords (wordList, wordListLength);
		ShuffleWords (wordList);
		return wordList;
	}

	private static List<string> GetRequiredWords () {
		List<string> result = new List<string> ();
		List<string> originalTargetSentence = GlobalManager.originalTargetSentence;
		result.AddRange (originalTargetSentence);
		result.AddRange (GlobalManager.currentTargetSentence);
		foreach (string word in originalTargetSentence) {
			int i = originalTargetSentence.Count;
			while (i < result.Count) {
				if (result [i] == word) {
					result.RemoveAt (i);
					i = result.Count;
				} else {
					i++;
				}
			}
		}

		return result;
	}

	private static void AddRandomWords (List<string> wordList, int desiredLength) {
		int numberToAdd = desiredLength - wordList.Count;
		List<string> newWords = new List<string> ();
		if(numberToAdd > 0) {
			//newWords = TextUtils.GetRandomWords (numberToAdd);
			for (int i = 0; i < numberToAdd; i++) {
				wordList.Add (TextUtils.GetRandomWord ());
			}
		}
		wordList.AddRange (newWords);
	}

	private static void ShuffleWords(List<string> wordList) {
		int n = wordList.Count;
		System.Random random = new System.Random ();
		while (n > 1) {
			n--;
			int k = random.Next (n + 1);
			string word = wordList [k];
			wordList [k] = wordList [n];
			wordList [n] = word;
		}
	}
}
