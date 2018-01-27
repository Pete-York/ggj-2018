using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class blocksController : MonoBehaviour {

	private float speed = 5.0f;
	public string word;

	public void SetWord(string word) {
		this.word = word;
		TextMesh textMesh = GetComponentInChildren<TextMesh> ();
		textMesh.text = word;
	}

	void Update ()
	{
		transform.Translate (Vector3.right * Time.deltaTime * speed);

		if (transform.position.x > 10.0f)
			Destroy (gameObject);
	}

}
