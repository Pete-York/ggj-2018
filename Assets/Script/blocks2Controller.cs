using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class blocks2Controller : MonoBehaviour {

	private float speed = 8.0f;

	void Update ()
	{
		transform.Translate (Vector3.right * Time.deltaTime * speed);

		if (transform.position.x > 10.0f)
			Destroy (gameObject);
	}
}
