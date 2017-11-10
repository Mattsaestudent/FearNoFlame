using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Analytics;

public class GameTime : MonoBehaviour {

    

	// Use this for initialization
	void Start ()
    {
        Analytics.CustomEvent("gameOver", new Dictionary<string, object>
        {
            {"timeingame",System.DateTime.Now}
        });


        Analytics.Transaction("lol",0.99m,"USD");

        Analytics.SetUserGender(Gender.Unknown);

        Analytics.SetUserBirthYear(1990);







    }

    // Update is called once per frame
    void Update () {
		
	}
}
