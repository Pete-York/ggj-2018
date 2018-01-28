﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LevelUI : MonoBehaviour {

	void Start () {
		List<string> targetSentence = GlobalManager.targetSentence;
		SetSentence (targetSentence);
	}

	private void SetSentence (List<string> targetSentence) {
		string combinedSentence = CombineSentence (targetSentence);
		Text text =  GetComponentInChildren<Text> ();
		text.text = combinedSentence;
	}

	private string CombineSentence (List<string> targetSentence) {
		string result = "Target Sentence: ";
		foreach (string word in targetSentence) {
			result += " " + word;
		}
		return result;
	}
}
