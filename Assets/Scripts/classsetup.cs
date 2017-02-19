using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class classsetup : MonoBehaviour {

    // Define Game Constants
    static int MAXNOOFSWAG = 20;        // Used to dimension the maximum number of Swag that can be used.
    static int MAXNOOFNPC  = 10;        // Used to dimension the maximum number of non playable characters that can be used.
    static int XCOORDINATE =  0;        // used as label for x co-ordinate in arrays
    static int YCOORDINATE =  1;        // used as label for y co-ordinate in arrays

    // define Classes that are used in the game (in reverse order so that the classes are available to other classes)

    /* SwagClass: Holds Swag reference, location and value
     * Methods: createSwag      Creates a new Swag item with Random Value
     *          deleteSwag      Deletes a Swag with a particular reference
     *          deleteAllSwag   Deletes all Swag values
     */
    private class SwagClass
    {
        string[] SwagRef;      // holds string used to identify each swag []= swag ref
        int[][] SwagPosition;   // holds the current SWAG position [] = swag ref []= co ord type
        int[] SwagValue;        // holds the SWAG Points value [] = swag ref

        /* createSwag: creates a new Swag reference with a random value
         * input:
         *      string swagRefString: String reference used for that swag
         *      int swagXPos: X location for the swag
         *      int swagYPos: Y location for the swag
         * output:
         *      Boolean: True = Success, False = Error
         */
        bool createSwag(string swagRefString, int swagXPos, int swagYPos)
        {
            int arrayRef;                   // used in for loop
            int nextAvailableEntry = -1;    // set to -1 so we can detect if no entries are free

            // first check if reference already exists (in reverse to make detecting next available array ref easy)
            for (arrayRef = MAXNOOFSWAG; arrayRef >= 0; arrayRef--)
            {
                if (SwagRef[arrayRef] == swagRefString)
                {
                    return (false);
                }

                if (SwagRef[arrayRef] == "")
                {
                    nextAvailableEntry = arrayRef;
                }
            }

            // If there are no available entries then nextAvailableEntry =-1 so return an error
            if (nextAvailableEntry == -1)
            {
                return (false);
            }

            // Add the Swag values to the next free location
            SwagRef[nextAvailableEntry] = swagRefString;
            SwagPosition[nextAvailableEntry][XCOORDINATE] = swagXPos;
            SwagPosition[nextAvailableEntry][YCOORDINATE] = swagYPos;

            // generate teh random swag value
            SwagValue[nextAvailableEntry] = Random.Range(1, 6) * 1000;  // random value of 1000,2000,3000,4000,5000

            return (true);
        }

        /* deleteSwag: deletes Swag with a specific reference and returns its points value
         * input:
         *      string swagRefString: String reference used for that swag
         * output:
         *      int: -1 = Error, all other values are the points value
         */
        int deleteSwag(string swagRefString)
        {
            int arrayRef;  // used in for loop

            for (arrayRef = 0; arrayRef <= MAXNOOFSWAG; arrayRef++)
            {
                if (SwagRef[arrayRef] == swagRefString)  // if swag ref matched
                {
                    // delete swag reference (effectively deletes it)
                    SwagRef[arrayRef] = "";
                    // return the points value
                    return (SwagValue[arrayRef]);
                }
            }

            // no match so return -1
            return (-1);

        }


        /* deleteAllSwag: deletes Swag with a specific reference and returns its points value
         * input:
         *      none
         * output:
         *      none
         */
        void deleteAllSwag()
        {
            int arrayRef;  // used in for loop

            for (arrayRef = 0; arrayRef <= MAXNOOFSWAG; arrayRef++)
            {
                // delete swag reference (effectively deletes it)
                SwagRef[arrayRef] = "";
            }
        }

    }





    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
