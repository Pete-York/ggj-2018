﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class FinalScoreManager : MonoBehaviour {
	private const string creditSceneName = "Credit";
	private const string originalSentenceUIElement = "OriginalSentence";
	private const string finalSentenceUIElement = "FinalSentence";

	void Start () {
		FillInOriginalAndFinalSentences ();
	}

	void Update () {
		if (Input.GetKey (KeyCode.Return)) {
			SceneManager.LoadScene (creditSceneName);
		}
	}

	private void FillInOriginalAndFinalSentences () {
		GameObject originalSentenceUI = GameObject.Find (originalSentenceUIElement);
		GameObject finalSentenceUI = GameObject.Find (finalSentenceUIElement);
		Text originalSentenceUIText = originalSentenceUI.GetComponent<Text> ();
		Text finalSentenceUIText = finalSentenceUI.GetComponent<Text> ();
		originalSentenceUIText.text = "Original Sentence - " + GetSentenceString (GlobalManager.originalTargetSentence);
		finalSentenceUIText.text = "Final Sentence - " + GetSentenceString (GlobalManager.currentTargetSentence);
	}

	private string GetSentenceString (List<string> sentence) {
		string result = "";
		foreach (string word in sentence) {
			result += " " + word;
		}
		return result;
	}
}
