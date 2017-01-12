using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class SettingsPageKeyPress : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () 
	{
		if (Input.GetKey (KeyCode.A)) {
			// Toggle Sound setting
			SceneManager.LoadScene("Settings");
		}

		if (Input.GetKey (KeyCode.D)) {
			// Toggle Difficulty setting
			SceneManager.LoadScene("Settings");
			}

		if (Input.GetKey (KeyCode.R)) {
			// return to main menu
			SceneManager.LoadScene("MainMenu");
		}
	}
}
