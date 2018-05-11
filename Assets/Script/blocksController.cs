using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class blocksController : MonoBehaviour {

	private float speed = 5.0f;
    public bool isFalling = false;
	public string word;

	public void SetWord(string word) {
		this.word = word;
		TextMesh textMesh = GetComponentInChildren<TextMesh> ();
		textMesh.text = word;
	}

    public void Fall()
    {
        isFalling = true;
    }

	void Update ()
	{
        Vector3 direction = isFalling ? Vector3.back : Vector3.right;
        transform.Translate (direction * Time.deltaTime * speed, Space.World);

        if (isFalling)
        {
            transform.RotateAround(Vector3.up, 0.1f);
        }

		if (transform.position.x > 10.0f || transform.position.z < -5.25)
			Destroy (gameObject);
	}

}
