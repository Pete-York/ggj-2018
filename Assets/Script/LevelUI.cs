using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LevelUI : MonoBehaviour {

	void Start () {
		List<string> targetSentence = GlobalManager.getCurrentTargetSentence();
		SetSentence (targetSentence);
	}

	private void SetSentence (List<string> targetSentence) {
		string combinedSentence = CombineSentence (targetSentence);
		Text text =  GetComponentInChildren<Text> ();
		text.text = combinedSentence;
	}

	private string CombineSentence (List<string> targetSentence) {
		return "Target Sentence: " + TextUtils.GetSentenceString (targetSentence);
	}
}
