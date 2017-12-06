using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OptionsS : MonoBehaviour {

    public GameObject Options;
    public GameObject Credits;
    public GameObject Controls;


	// Use this for initialization
	void Start ()
    {
        Options = GameObject.FindGameObjectWithTag("Options");
        Credits = GameObject.FindGameObjectWithTag("Credits");
        Controls = GameObject.FindGameObjectWithTag("Controls");

        Options.SetActive(true);
        Credits.SetActive(true);
        Controls.SetActive(false);
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void Controlss()
    {
        Options.SetActive(false);
        Credits.SetActive(false);
        Controls.SetActive(true);
    }

    public void OptionsScreen()
    {
        Options.SetActive(true);
        Credits.SetActive(true);
        Controls.SetActive(false);
    }
}
