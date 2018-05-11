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
	public Slider minWordCountInput;
	public Slider maxWordCountInput;

	
	void Start () {
		Button button = gameObject.GetComponent<Button>();
		button.onClick.AddListener (StartGame);
		playerCountInput = GameObject.Find (playerCountInputName);
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
		GlobalManager.setOriginalTargetSentence (wordList);
		GlobalManager.setCurrentTargetSentence (wordList);
	}

	private int SelectSentenceLength () {
		int result = 0;
		int minWordCount = (int) minWordCountInput.value;
		int maxWordCount = (int) maxWordCountInput.value;
		if (minWordCount < maxWordCount) {
			int range = maxWordCount - minWordCount;
			System.Random rng = new System.Random ();
			int index = rng.Next (range - 1);
			result = minWordCount + index;
		} else if (minWordCount == maxWordCount) {
			result = minWordCount;
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
			print (e.ToString());
			inputField.text = "this was not a number";
		}
		return result;
	}

	private bool CheckInitialSettings () {
		bool result = true;
		result = result && GlobalManager.getOriginalTargetSentence().Count > 0;
		result = result && GlobalManager.getCurrentTargetSentence().Count > 0;
		result = result && GlobalManager.numberOfPlayers > 0;
		result = result && GlobalManager.currentPlayer == 1;
		return result;
	}
}
