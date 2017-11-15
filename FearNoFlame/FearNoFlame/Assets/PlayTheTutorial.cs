using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayTheTutorial : MonoBehaviour {

    public GameObject up;
    public GameObject down;
    public GameObject right;
    public GameObject left;

    public GameObject camera;

    public GameObject wheretobuild;
    public GameObject wheretobuildone;
    public GameObject wheretobuildtwo;
    public GameObject wheretobuildthree;

    public GameObject Lookforthefire;
    public GameObject BuildICV;
    public GameObject BuildtheDozer;

    public GameObject toggle;
  

	// Use this for initialization
	void Start ()
    {
        up = GameObject.Find("Up");
        down = GameObject.Find("Down");
        right = GameObject.Find("Right");
        left = GameObject.Find("Left");
        wheretobuild = GameObject.Find("Where to build");
        wheretobuildone = GameObject.Find("Where to build (1)");
        wheretobuildtwo = GameObject.Find("Where to build (2)");
        wheretobuildthree = GameObject.Find("Where to build (3)");
        Lookforthefire = GameObject.Find("Look for the fire");
        BuildICV = GameObject.Find("BuildICV");
        BuildtheDozer = GameObject.Find("Build the dozer");

        camera = GameObject.Find("Main Camera");

        toggle = GameObject.Find("Toggle");

        wheretobuild.SetActive(false);
        wheretobuildone.SetActive(false);
        wheretobuildtwo.SetActive(false);
        wheretobuildthree.SetActive(false);
        Lookforthefire.SetActive(false);
        BuildICV.SetActive(false);
        BuildtheDozer.SetActive(false);


        

    }

    // Update is called once per frame
    void Update()
    {
        if (camera.GetComponent<CameraLookAround>().isup == true)
        {
            up.SetActive(false);
        }
        if (camera.GetComponent<CameraLookAround>().isdown == true)
        {
            down.SetActive(false);
        }
        if (camera.GetComponent<CameraLookAround>().isrigh == true)
        {
            right.SetActive(false);
        }
        if (camera.GetComponent<CameraLookAround>().isleft == true)
        {
            left.SetActive(false);
        }

        if (camera.GetComponent<CameraLookAround>().isup == true && camera.GetComponent<CameraLookAround>().isdown == true && camera.GetComponent<CameraLookAround>().isrigh == true && camera.GetComponent<CameraLookAround>().isleft == true)
        {
            Lookforthefire.SetActive(true);
        }

        if(toggle.GetComponent<FoundTheFire>().foundthefire == true)
        {
            Lookforthefire.SetActive(false);
            BuildICV.SetActive(true);
        }
     }
 }

