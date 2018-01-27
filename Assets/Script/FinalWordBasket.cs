using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FinalWordBasket : MonoBehaviour {
	private string word = "_____";
	
	void OnTriggerStay (Collider other)
	{
		if (other.tag == ("block") || other.tag == "block2") 
		{
			string blockWord = other.GetComponent<blocks2Controller> ().word;
			SetWord (blockWord);
			Destroy (other.gameObject);
		}
	}

	private void SetWord(string word) {
		this.word = word;
		TextMesh textMesh = GetComponentInChildren<TextMesh> ();
		textMesh.text = word;
	}
}
