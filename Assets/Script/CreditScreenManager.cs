using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CreditScreenManager : MonoBehaviour {
	private const string menuSceneName = "Menu";

	// Update is called once per frame
	void Update () {
		if (Input.GetKey (KeyCode.Return)) {
			SceneManager.LoadScene (menuSceneName);
		}
	}
}
