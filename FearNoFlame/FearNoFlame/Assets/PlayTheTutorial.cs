using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayTheTutorial : MonoBehaviour {

    public GameObject up;
    public GameObject down;
    public GameObject right;
    public GameObject left;

    public GameObject camera;


    public GameObject Lookforthefire;
    public GameObject BuildICV;
    public GameObject BuildtheDozer;

    public GameObject toggle;

    public GameObject prefab;

    public GameObject WheretobuildICV;
    public GameObject WheretobuildICVOne;
    public GameObject WheretobuildICVTwo;
    public GameObject WheretobuildICVThree;

    public GameObject cube;

    public GameObject smallSelecthighlight;
    public GameObject smallSelecthighlightOne;
    public GameObject smallSelecthighlighttwo;
    public GameObject smallSelecthighlightThree;



    // Use this for initialization
    void Start ()
    {
        up = GameObject.Find("Up");
        down = GameObject.Find("Down");
        right = GameObject.Find("Right");
        left = GameObject.Find("Left");
       
        
        BuildICV = GameObject.Find("BuildICV");
        BuildtheDozer = GameObject.Find("Build the dozer");

        camera = GameObject.Find("Main Camera");

        toggle = GameObject.Find("Toggle");

        WheretobuildICV = GameObject.Find("WheretobuildICV");
        WheretobuildICVOne = GameObject.Find("WheretobuildICV (1)");
        WheretobuildICVTwo = GameObject.Find("WheretobuildICV (2)");
        WheretobuildICVThree = GameObject.Find("WheretobuildICV (3)");

        smallSelecthighlight = GameObject.Find("smallselecthightlight");
        smallSelecthighlightOne = GameObject.Find("smallselecthightlight (1)");
        smallSelecthighlighttwo = GameObject.Find("smallselecthightlight (2)");
        smallSelecthighlightThree = GameObject.Find("smallselecthightlight (3)");


        Lookforthefire.SetActive(false);
        BuildICV.SetActive(false);
        BuildtheDozer.SetActive(false);

        WheretobuildICV.SetActive(false);
        WheretobuildICVOne.SetActive(false);
        WheretobuildICVTwo.SetActive(false);
        WheretobuildICVThree.SetActive(false);
        smallSelecthighlight.SetActive(false);
        smallSelecthighlightOne.SetActive(false);
        smallSelecthighlighttwo.SetActive(false);
        smallSelecthighlightThree.SetActive(false);

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

        if(BuildICV.activeInHierarchy)
        {
            Lookforthefire.SetActive(false);

            var distanceToCube = Vector3.Distance(Camera.main.transform.position, cube.transform.position);

            Debug.Log(distanceToCube);

            if(distanceToCube > 43)
            {
                WheretobuildICV.SetActive(true);
                WheretobuildICVOne.SetActive(true);
                WheretobuildICVTwo.SetActive(true);
                WheretobuildICVThree.SetActive(true);
                smallSelecthighlight.SetActive(true);
                smallSelecthighlightOne.SetActive(true);
                smallSelecthighlighttwo.SetActive(true);
                smallSelecthighlightThree.SetActive(true);
            }

        }



    }
 }

