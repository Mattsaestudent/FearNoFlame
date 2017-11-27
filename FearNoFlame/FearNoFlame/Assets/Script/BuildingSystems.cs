using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class BuildingSystems : MonoBehaviour
{

	public Button Dozerspawnbutton;
	public Button ICVspawnbutton;
	public Button LTspawnbutton;
	public Button FourFourspawnbutton;
	public Button ThreeFourspawnbutton;
	public Button Twofourspawnbutton;
	public Button waterbomerspawnbutton;
	public Button helitackspawnbutton;

    public GameObject[] selectGameObject;

    public GameObject selectedObject;

    public GameObject noGameObject;

    public string buttonName;

    public bool clicked = false;

    public GameManager Gm;

    // Use this for initialization
    void Start () 
	{
		Button DozerspawnBTN = Dozerspawnbutton.GetComponent<Button>();
		DozerspawnBTN.onClick.AddListener(Dozerspawn);

		Button ICVspawnBTN = ICVspawnbutton.GetComponent<Button>();
        ICVspawnBTN.onClick.AddListener(ICVspawn);

        Button LTspawnBTN = LTspawnbutton.GetComponent<Button>();
        LTspawnBTN.onClick.AddListener( LTspawn);

        Button FourFourspawnBTN = FourFourspawnbutton.GetComponent<Button>();
        FourFourspawnBTN.onClick.AddListener( Fourfourspawn);

        Button ThreeFourspawnBTN = ThreeFourspawnbutton.GetComponent<Button>();
        ThreeFourspawnBTN.onClick.AddListener(Threefourspawn);

        Button TwofourspawnBTN = Twofourspawnbutton.GetComponent<Button>();
        TwofourspawnBTN.onClick.AddListener(Twothreespawn);

        Button waterbomerspawnBTN = waterbomerspawnbutton.GetComponent<Button>();
        waterbomerspawnBTN.onClick.AddListener(Waterbomberspawn);

        Button helitackspawnBTN = helitackspawnbutton.GetComponent<Button>();
        helitackspawnBTN.onClick.AddListener(Helitackspawn);

    }

    // Update is called once per frame
    void Update()
    {
       
        if (!EventSystem.current.IsPointerOverGameObject())
        {

            if (Input.GetMouseButtonDown(0))
            {
                RaycastHit hit;
                Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

                if (selectedObject != null)
                {

                    if (Physics.Raycast(ray, out hit))
                    {
                        if (hit.transform.tag == "terrain")
                        {
                           

                            if (Gm.waterTotal < 149)
                            {
                                return;
                            }
                            else
                            {
                                Instantiate(selectedObject, new Vector3(hit.point.x, 0f, hit.point.z), Quaternion.Euler(0, 90, 0));
                            }

                            if (selectedObject == selectGameObject[0])
                            {
                                Gm.waterTotal -= 250;
                            }
                            else if (selectedObject == selectGameObject[1])
                            {
                                Gm.waterTotal -= 250;
                            }
                            else if (selectedObject == selectGameObject[2])
                            {
                                Gm.waterTotal -= 150;
                            }
                            else if (selectedObject == selectGameObject[3])
                            {
                                Gm.waterTotal -= 550;
                            }
                            else if (selectedObject == selectGameObject[4])
                            {
                                Gm.waterTotal -= 450;
                            }
                            else if (selectedObject == selectGameObject[5])
                            {
                                Gm.waterTotal -= 350;
                            }
                            else if (selectedObject == selectGameObject[6])
                            {
                                Gm.waterTotal -= 950;
                            }
                            else if (selectedObject == selectGameObject[7])
                            {
                                Gm.waterTotal -= 1000;
                            }

                            else if (GameObject.Find("ICV(Clone)") != null)
                            {
                                return;
                            }

                        }
                        else
                        {
                            return;
                        }

                    }
                }


            }
        }
    }

    void OnMouseDown()
    {
       
    }

    void Dozerspawn()
	{
        selectedObject = selectGameObject[0];
       

    }

    void ICVspawn()
    {
        selectedObject = selectGameObject[1];

        
    }

    void LTspawn()
    {
        selectedObject = selectGameObject[2];
       
    }

    void Fourfourspawn()
    {
        selectedObject = selectGameObject[3];
      
    }

    void Threefourspawn()
    {
        selectedObject = selectGameObject[4];
        
    }

    void Twothreespawn()
    {
        selectedObject = selectGameObject[5];
        
    }

    void Waterbomberspawn()
    {
        selectedObject = selectGameObject[6];

    }

    void Helitackspawn()
    {
        selectedObject = selectGameObject[7];
        
    }
}
