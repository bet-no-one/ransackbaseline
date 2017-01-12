using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class MainMenuKeyPress : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () 
	{
		if (Input.GetKey (KeyCode.Space))
			SceneManager.LoadScene ("Settings");
		if (Input.GetKey (KeyCode.S))
			SceneManager.LoadScene ("Settings");
		if (Input.GetKey (KeyCode.H))
			SceneManager.LoadScene ("Settings");
		if (Input.GetKey (KeyCode.Q))
			Application.Quit ();
	}
}
