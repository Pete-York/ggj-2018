using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class FinalScoreManager : MonoBehaviour {
	private const string creditSceneName = "Credit";
	private const string originalSentenceUIElement = "OriginalSentence";
	private const string intermediateSentenceUIElement = "IntermediateSentence";
	private const string finalSentenceUIElement = "FinalSentence";
	private int intermediateSentenceIndex = 0;

	void Start () {
		FillInOriginalAndFinalSentences ();
		GetNextIntermediateSentence ();
	}

	void Update () {
		if (Input.GetKeyDown (KeyCode.Return)) {
			SceneManager.LoadScene (creditSceneName);
		}
		if (Input.GetKeyDown (KeyCode.Space)) {
			GetNextIntermediateSentence ();
		}
	}

	private void FillInOriginalAndFinalSentences () {
		GameObject originalSentenceUI = GameObject.Find (originalSentenceUIElement);
		GameObject finalSentenceUI = GameObject.Find (finalSentenceUIElement);
		Text originalSentenceUIText = originalSentenceUI.GetComponent<Text> ();
		Text finalSentenceUIText = finalSentenceUI.GetComponent<Text> ();
		originalSentenceUIText.text = "Original Sentence - " + GetSentenceString (GlobalManager.getOriginalTargetSentence());
		finalSentenceUIText.text = "Final Sentence - " + GetSentenceString (GlobalManager.getCurrentTargetSentence());
	}

	private string GetSentenceString (List<string> sentence) {
		string result = "";
		foreach (string word in sentence) {
			result += " " + word;
		}
		return result;
	}

	private void GetNextIntermediateSentence () {
		List<List<string>> intermediateSentences = GlobalManager.getAllSentences ();
		if (intermediateSentences.Count > 0) {
			if (intermediateSentenceIndex >= intermediateSentences.Count) {
				intermediateSentenceIndex = 0;
			}
			List<string> intermediateSentence = intermediateSentences [intermediateSentenceIndex];

			GameObject intermediateSentenceUI = GameObject.Find (intermediateSentenceUIElement);
			Text intermediateSentenceUIText = intermediateSentenceUI.GetComponent<Text> ();

			intermediateSentenceUIText.text = "Intermediate Sentence - " + GetSentenceString (intermediateSentence);
			intermediateSentenceIndex++;
		}
	}
}
