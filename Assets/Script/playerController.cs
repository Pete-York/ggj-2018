using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerController : MonoBehaviour {

	public GameObject basket;
	public GameObject block2;

	private float speed = 0.2f;
	private Vector3 offsetFacingLeft;
	private Vector3 offsetFacingRight;
	private string word = "";
	private int basketFlag = 0;
	private Vector3 faceLeft;
	private Vector3 faceRight;

	void Start ()
	{
		offsetFacingLeft = basket.transform.position - transform.position;
		offsetFacingRight = offsetFacingLeft + new Vector3 (0.3f, 0.0f, 0.0f);
		faceLeft = new Vector3 (1.5f, 1.5f, 1.8f);
		faceRight = new Vector3 (-1.5f, 1.5f, 1.8f);
	}

	void Update ()
	{
		float moveVertical = Input.GetAxis ("Vertical");
		transform.Translate (Vector3.forward * moveVertical * speed);

		if (basketFlag == 0) 
		{
			basket.transform.position = transform.position + offsetFacingLeft;
			basket.GetComponent<TextMesh> ().anchor = TextAnchor.MiddleRight;
		} 
		else 
		{
			basket.transform.position = transform.position + offsetFacingRight;
			basket.GetComponent<TextMesh> ().anchor = TextAnchor.MiddleLeft;
		}

		if (Input.GetKey ("space") && basketFlag == 1) 
		{
			ThrowWord ();
			transform.localScale = faceLeft;
		}

	}

	private void ThrowWord () {
		Vector3 spawnPosition = transform.position;
		Quaternion spawnRotation = Quaternion.identity;
		GameObject thrownBlock = Instantiate (block2, spawnPosition, spawnRotation);
		thrownBlock.GetComponent<blocks2Controller> ().SetWord (word);
		basketFlag = 0;
		SetWord ("");
	}
		
	void OnTriggerStay (Collider other)
	{
		if (other.tag == ("playerBoundary_Top"))
			transform.Translate (Vector3.back * speed * 1.5f);

		if (other.tag == ("playerBoundary_Bottom"))
			transform.Translate (Vector3.forward * speed * 1.5f);

		if (other.tag == ("block")) 
		{
			if (basketFlag != 1) {
				string blockWord = other.GetComponent<blocksController> ().word;
				SetWord (blockWord);
				basketFlag = 1;
			}
			Destroy (other.gameObject);
			transform.localScale = faceRight;
		}
	}

	private void SetWord (string word)
	{
		this.word = word;
		basket.GetComponent<TextMesh> ().text = word;
	}
}
