using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerController : MonoBehaviour {

	public GameObject basket;
	public GameObject block2;

	private float speed = 0.2f;
	private Vector3 offset;
	private int basketFlag = 0;

	void Start ()
	{
		offset = basket.transform.position - transform.position;
	}

	void Update ()
	{
		float moveVertical = Input.GetAxis ("Vertical");
		transform.Translate (Vector3.forward * moveVertical * speed);

		basket.transform.position = transform.position + offset;

		if (Input.GetKey ("space") && basketFlag == 1) 
		{
			Vector3 spawnPosition = transform.position;
			Quaternion spawnRotation = Quaternion.identity;
			Instantiate (block2, spawnPosition, spawnRotation);
			basketFlag = 0;
		}

	}
		
	void OnTriggerStay (Collider other)
	{
		if (other.tag == ("playerBoundary_Top"))
			transform.Translate (Vector3.back * speed * 1.5f);

		if (other.tag == ("playerBoundary_Bottom"))
			transform.Translate (Vector3.forward * speed * 1.5f);

		if (other.tag == ("block")) 
		{
			Destroy (other.gameObject);
			basket.GetComponent<TextMesh> ().text = "Yo";
			basketFlag = 1;
		}
	}
}
