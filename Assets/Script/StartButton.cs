using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class StartButton : MonoBehaviour {
	
	void Start () {
		Button button = gameObject.GetComponent<Button>();
		button.onClick.AddListener (StartGame);
	}

	void StartGame() {
		SelectTargetSentence ();
		SceneManager.LoadScene ("Demo");
	}

	private void SelectTargetSentence() {
		string targetSentence = TextUtils.GetRandomLineOfLength (6);
		string[] wordArray = targetSentence.Split (' ');
		List<string> wordList = new List<string> ();
		foreach (string word in wordArray) {
			wordList.Add(word);
		}
		GlobalManager.originalTargetSentence = wordList;
		GlobalManager.currentTargetSentence = wordList;
	}
}
