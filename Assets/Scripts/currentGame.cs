using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class currentGame : MonoBehaviour {

    // create an instance of currentGame for other scripts to access
    public static currentGame instance = null;

    // Declare public variables for this class
    public int currentScore;            // holds overall score for the current game (over all levels)
    public int playerLives;             // holds the current number of lives (0 = no lives)
    public int swagValueThisScreen;     // holds the current number of swag points for this screen (triggers door opening)
    public int timeCounterPoints;       // hold the current time points for this screen


    // very first event
    void Awake() {
        //Check if instance already exists
        if (instance == null)

            //if not, set instance to this
            instance = this;

        //If instance already exists and it's not this:
        else if (instance != this)

            //Then destroy this. This means that there can only be one ( otherwise the highlanders will get it)
            Destroy(gameObject);

        //Sets this to not be destroyed when reloading scene
        DontDestroyOnLoad(gameObject);

    }


    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    void newGame (int difficultySetting)
    {
        currentScore = 0;
        playerLives = 3;
        swagValueThisScreen = 0;
        if (difficultySetting<1)
        {
            difficultySetting = 1;
        }

        timeCounterPoints = (int) (1000 / difficultySetting);
    }

    void newScreen(int difficultySetting)
    {
        swagValueThisScreen = 0;
        if (difficultySetting < 1)
        {
            difficultySetting = 1;
        }

        timeCounterPoints = (int)(1000 / difficultySetting);
    }

}



