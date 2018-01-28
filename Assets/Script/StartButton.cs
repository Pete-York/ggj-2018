using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System;

public class StartButton : MonoBehaviour {
	private const string playerCountInputName = "PlayerCount";
	private const string minWordCountInputName = "SentenceLengthMin";
	private const string maxWordCountInputName = "SentenceLengthMax";

	private GameObject playerCountInput;
	private GameObject minWordCountInput;
	private GameObject maxWordCountInput;

	
	void Start () {
		Button button = gameObject.GetComponent<Button>();
		button.onClick.AddListener (StartGame);
		playerCountInput = GameObject.Find (playerCountInputName);
		minWordCountInput = GameObject.Find (minWordCountInputName);
		maxWordCountInput = GameObject.Find (maxWordCountInputName);
	}

	void StartGame() {
		SelectTargetSentence ();
		SetPlayerAndRound ();
		if (CheckInitialSettings()) {
			SceneManager.LoadScene ("Demo");
		}
	}

	private void SelectTargetSentence () {
		int length = SelectSentenceLength ();
		string targetSentence = TextUtils.GetRandomLineOfLength (length);
		string[] wordArray = targetSentence.Split (' ');
		List<string> wordList = new List<string> ();
		foreach (string word in wordArray) {
			wordList.Add(word);
		}
		GlobalManager.originalTargetSentence = wordList;
		GlobalManager.currentTargetSentence = wordList;
	}

	private int SelectSentenceLength () {
		int result = 0;
		InputField minWordCountInputField = minWordCountInput.GetComponent<InputField> ();
		InputField maxWordCountInputField = maxWordCountInput.GetComponent<InputField> ();
		int minWordCount = GetIntFromInput (minWordCountInputField);
		int maxWordCount = GetIntFromInput (maxWordCountInputField);
		if (minWordCount <= maxWordCount) {
			int range = maxWordCount - minWordCount;
			System.Random rng = new System.Random ();
			int index = rng.Next (range - 1);
			result = minWordCount + index;
		}
		return result;
	}

	private void SetPlayerAndRound() {
		InputField playerCountInputText = playerCountInput.GetComponent<InputField> ();
		int playerCount = GetIntFromInput (playerCountInputText);
		GlobalManager.numberOfPlayers = playerCount;
		GlobalManager.currentPlayer = 1;
	}

	private int GetIntFromInput (InputField inputField) {
		int result = 0;
		try {
			result = int.Parse(inputField.text);
		} 
		catch (Exception e) {
			inputField.text = "this was not a number";
		}
		return result;
	}

	private bool CheckInitialSettings () {
		bool result = true;
		result = result && GlobalManager.originalTargetSentence.Count > 0;
		result = result && GlobalManager.currentTargetSentence.Count > 0;
		result = result && GlobalManager.numberOfPlayers > 0;
		result = result && GlobalManager.currentPlayer == 1;
		return result;
	}
}
