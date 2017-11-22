using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FoundTheFire : MonoBehaviour {

    public bool foundthefire;

	// Use this for initialization
	void Start ()
    {
        foundthefire = false;
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void Howyoufoundthefire()
    {
        foundthefire = true;
    }
}
