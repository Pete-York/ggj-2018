using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class NextPlayerController : MonoBehaviour {
	private const string levelSceneName = "Demo";

	void Update () {
		if (Input.GetKey ("space")) {
			SceneManager.LoadScene (levelSceneName);
		}
	}
}
