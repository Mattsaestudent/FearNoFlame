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
    void Update ()
    {
        Debug.Log(selectedObject);
        if (!EventSystem.current.IsPointerOverGameObject())
        {
            if (Input.GetMouseButton(0))
            {
                Vector3 mousePos = Input.mousePosition;
                mousePos.z = 10.0f;
                mousePos = Camera.main.ScreenToWorldPoint(mousePos);
                mousePos.y = 1f;
                clicked = true;
                if (clicked == true)
                {
                    Instantiate(selectedObject, mousePos, Quaternion.Euler(90,0,0));
               
                    clicked = false;
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
