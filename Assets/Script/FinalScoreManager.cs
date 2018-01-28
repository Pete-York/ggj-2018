using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class FinalScoreManager : MonoBehaviour {
	private const string menuSceneName = "Menu";
	private const string originalSentenceUIElement = "OriginalSentence";
	private const string finalSentenceUIElement = "FinalSentence";

	void Start () {
		FillInOriginalAndFinalSentences ();
	}

	void Update () {
		if (Input.GetKey ("space")) {
			SceneManager.LoadScene (menuSceneName);
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
		
	}
}
