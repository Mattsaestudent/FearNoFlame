using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayTheTutorial : MonoBehaviour {

    public Button LTbutton;
    public Button dozerB;

    public GameObject dozerWhatToDo;

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

    public GameObject wheretoBuildDozer;
    public GameObject wheretoBuildDozerOne;
    public GameObject wheretoBuildDozerTwo;
    public GameObject wheretoBuildDozerThree;

    public GameObject dozerHighlight;
    public GameObject dozerHighlightOne;
    public GameObject dozerHighlightTwo;
    public GameObject dozerHighlightThree;

    public GameObject ICVbuttonhighlight;
    public GameObject ICVbuttonhighlightOne;
    public GameObject ICVbuttonhighlightTwo;
    public GameObject ICVbuttonhighlightThree;

    public GameObject DozerbuttonhighLight;
    public GameObject DozerbuttonhighLightOne;
    public GameObject DozerbuttonhighLightTwo;
    public GameObject DozerbuttonhighLightThree;

    public GameObject buttonHighLight;
    public GameObject buttonHighLightOne;
    public GameObject buttonHighLightTwo;
    public GameObject buttonHighLightThree;

    public GameObject dozerMovementtut;
    public GameObject dozerMovementtutOne;
    public GameObject dozerMovementtutTwo;
    public GameObject dozerMovementtutThree;

    public GameObject theWhiteGround;

    public GameObject Down;

    

    

    public bool ICVbuttonON;

    public bool DozerButtonON;







    // Use this for initialization
    void Start ()
    {
        

        ICVbuttonON = false;

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

        wheretoBuildDozer = GameObject.Find("Wheretobuilddozer");
        wheretoBuildDozerOne = GameObject.Find("Wheretobuilddozer (1)");
        wheretoBuildDozerTwo = GameObject.Find("Wheretobuilddozer (2)");
        wheretoBuildDozerThree = GameObject.Find("Wheretobuilddozer (3)");

        dozerHighlight = GameObject.Find("Dozer red");
        dozerHighlightOne = GameObject.Find("Dozer red (1)");
        dozerHighlightTwo = GameObject.Find("Dozer red (2)");
        dozerHighlightThree = GameObject.Find("Dozer red (3)");

        ICVbuttonhighlight = GameObject.Find("ICVButtonHigh");
        ICVbuttonhighlightOne = GameObject.Find("ICVButtonHigh(1)");
        ICVbuttonhighlightTwo = GameObject.Find("ICVButtonHigh(2)");
        ICVbuttonhighlightThree = GameObject.Find("ICVButtonHigh(3)");

        DozerbuttonhighLight = GameObject.Find("DozerButtonhigh");
        DozerbuttonhighLightOne = GameObject.Find("DozerButtonhigh (1)");
        DozerbuttonhighLightTwo = GameObject.Find("DozerButtonhigh (2)");
        DozerbuttonhighLightThree = GameObject.Find("DozerButtonhigh (3)");

        buttonHighLight = GameObject.Find("ButtonHigh");
        buttonHighLightOne = GameObject.Find("ButtonHigh (1)");
        buttonHighLightTwo = GameObject.Find("ButtonHigh (2)");
        buttonHighLightThree = GameObject.Find("ButtonHigh (3)");

        dozerMovementtut = GameObject.Find("DM");
        dozerMovementtutOne = GameObject.Find("DM (1)");
        dozerMovementtutTwo = GameObject.Find("DM (2)");
        dozerMovementtutThree = GameObject.Find("DM (3)");

        theWhiteGround = GameObject.Find("TheWhiteGround");

        Down = GameObject.Find("Down");

        dozerWhatToDo = GameObject.Find("Dozer");





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

        wheretoBuildDozer.SetActive(false);
        wheretoBuildDozerOne.SetActive(false);
        wheretoBuildDozerTwo.SetActive(false);
        wheretoBuildDozerThree.SetActive(false);

        dozerHighlight.SetActive(false);
        dozerHighlightOne.SetActive(false);
        dozerHighlightTwo.SetActive(false);
        dozerHighlightThree.SetActive(false);

        ICVbuttonhighlight.SetActive(false);
        ICVbuttonhighlightOne.SetActive(false);
        ICVbuttonhighlightTwo.SetActive(false);
        ICVbuttonhighlightThree.SetActive(false);

        DozerbuttonhighLight.SetActive(false);
        DozerbuttonhighLightOne.SetActive(false);
        DozerbuttonhighLightTwo.SetActive(false);
        DozerbuttonhighLightThree.SetActive(false);

        buttonHighLight.SetActive(false);
        buttonHighLightOne.SetActive(false);
        buttonHighLightTwo.SetActive(false);
        buttonHighLightThree.SetActive(false);

        dozerMovementtut.SetActive(false);
        dozerMovementtutOne.SetActive(false);
        dozerMovementtutTwo.SetActive(false);
        dozerMovementtutThree.SetActive(false);

        dozerWhatToDo.SetActive(false);

        theWhiteGround.SetActive(false);



        Button LTbuttoned = LTbutton.GetComponent<Button>();
        LTbutton.onClick.AddListener(buttonHighLigh);
        Button dozerBt = dozerB.GetComponent<Button>();
        dozerB.onClick.AddListener(DozerButtonOnNow);

    }

    // Update is called once per frame
    void Update()
    {
        if(GetComponent<PlayTheTutorial>().enabled == false)
        {
            ICVbuttonON = false;
            DozerButtonON = false;

        }

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
            up.SetActive(true);
            
        }

        if(BuildICV.activeInHierarchy)
        {
            Lookforthefire.SetActive(false);
            up.SetActive(false);

            var distanceToCube = Vector3.Distance(Camera.main.transform.position, cube.transform.position);



            Down.SetActive(true);

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

        if (GameObject.Find("ICV(Clone)") != null)
        {
            Lookforthefire.SetActive(false);
            up.SetActive(false);
            Down.SetActive(false);
            WheretobuildICV.SetActive(false);
            WheretobuildICVOne.SetActive(false);
            WheretobuildICVTwo.SetActive(false);
            WheretobuildICVThree.SetActive(false);
            smallSelecthighlight.SetActive(false);
            smallSelecthighlightOne.SetActive(false);
            smallSelecthighlighttwo.SetActive(false);
            smallSelecthighlightThree.SetActive(false);

            BuildICV.SetActive(false);

            BuildtheDozer.SetActive(true);
            wheretoBuildDozer.SetActive(true);
            wheretoBuildDozerOne.SetActive(true);
            wheretoBuildDozerTwo.SetActive(true);
            wheretoBuildDozerThree.SetActive(true);

            ICVbuttonON = false;

            dozerHighlight.SetActive(true);
            dozerHighlightOne.SetActive(true);
            dozerHighlightTwo.SetActive(true);
            dozerHighlightThree.SetActive(true);

            DozerbuttonhighLight.SetActive(true);
            DozerbuttonhighLightOne.SetActive(true);
            DozerbuttonhighLightTwo.SetActive(true);
            DozerbuttonhighLightThree.SetActive(true);


        }

        if (GameObject.Find("D10spawn 1(Clone)") != null)
        {
            BuildtheDozer.SetActive(false);
            wheretoBuildDozer.SetActive(false);
            wheretoBuildDozerOne.SetActive(false);
            wheretoBuildDozerTwo.SetActive(false);
            wheretoBuildDozerThree.SetActive(false);
            dozerHighlight.SetActive(false);
            dozerHighlightOne.SetActive(false);
            dozerHighlightTwo.SetActive(false);
            dozerHighlightThree.SetActive(false);

            DozerbuttonhighLight.SetActive(false);
            DozerbuttonhighLightOne.SetActive(false);
            DozerbuttonhighLightTwo.SetActive(false);
            DozerbuttonhighLightThree.SetActive(false);
            DozerButtonON = false;

            dozerWhatToDo.SetActive(true);
            dozerMovementtut.SetActive(true);
            dozerMovementtutOne.SetActive(true);
            dozerMovementtutTwo.SetActive(true);
            dozerMovementtutThree.SetActive(true);
        }

            if (ICVbuttonON == true)
        {
            ICVbuttonhighlight.SetActive(true);
            ICVbuttonhighlightOne.SetActive(true);
            ICVbuttonhighlightTwo.SetActive(true);
            ICVbuttonhighlightThree.SetActive(true);
            Down.SetActive(false);
        }
        else
        {
            ICVbuttonhighlight.SetActive(false);
            ICVbuttonhighlightOne.SetActive(false);
            ICVbuttonhighlightTwo.SetActive(false);
            ICVbuttonhighlightThree.SetActive(false);
        }

        if(DozerButtonON == true)
        {
            DozerbuttonhighLight.SetActive(true);
            DozerbuttonhighLightOne.SetActive(true);
            DozerbuttonhighLightTwo.SetActive(true);
            DozerbuttonhighLightThree.SetActive(true);
        }
        else
        {
            DozerbuttonhighLight.SetActive(false);
            DozerbuttonhighLightOne.SetActive(false);
            DozerbuttonhighLightTwo.SetActive(false);
            DozerbuttonhighLightThree.SetActive(false);
        }

        if (GameObject.FindGameObjectWithTag("dozer") != null && GameObject.FindGameObjectWithTag("dozer").GetComponent<GradingGround>().movementNumber >= 360)
            {
                dozerWhatToDo.SetActive(false);
                dozerMovementtut.SetActive(false);
                dozerMovementtutOne.SetActive(false);
                dozerMovementtutTwo.SetActive(false);
                dozerMovementtutThree.SetActive(false);
                theWhiteGround.SetActive(true);
                buttonHighLight.SetActive(true);
                buttonHighLightOne.SetActive(true);
                buttonHighLightTwo.SetActive(true);
                buttonHighLightThree.SetActive(true);
            }
    


    }



     void OnDisable()
    {
        ICVbuttonON = false;
        DozerButtonON = false;
    }

    void buttonHighLigh()
    {
        ICVbuttonON = true;
        
    }

    void DozerButtonOnNow()
    {
        DozerButtonON = true;
    }

 }

