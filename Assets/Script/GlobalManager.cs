using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GlobalManager : MonoBehaviour {
	private static List<string> originalTargetSentence = new List<string> ();
	private static List<string> currentTargetSentence = new List<string> ();
	private static List<List<string>> allSentences = new List<List<string>> ();
	public static int numberOfPlayers;
	public static int currentPlayer;

	public static List<string> getOriginalTargetSentence () {
		if (originalTargetSentence.Count < 1) {
			originalTargetSentence.Add ("CHINESE");
			originalTargetSentence.Add ("DINOSAUR");
			originalTargetSentence.Add ("WHISPER");
			originalTargetSentence.Add ("COMICS");
		}
		return originalTargetSentence;
	}

	public static void setOriginalTargetSentence (List<string> sentence) {
		originalTargetSentence = sentence;
	}

	public static List<string> getCurrentTargetSentence () {
		if (currentTargetSentence.Count < 1) {
			currentTargetSentence.Add ("CHINESE");
			currentTargetSentence.Add ("DINOSAUR");
			currentTargetSentence.Add ("WHISPER");
			currentTargetSentence.Add ("COMICS");
		}
		return currentTargetSentence;
	}

	public static void setCurrentTargetSentence (List<string> sentence) {
		currentTargetSentence = sentence;
	}

	public static List<List<string>> getAllSentences() {
		return allSentences;
	}

	public static void addIntermediateSentence (List<string> sentence) {
		allSentences.Add (sentence);
	}
}

