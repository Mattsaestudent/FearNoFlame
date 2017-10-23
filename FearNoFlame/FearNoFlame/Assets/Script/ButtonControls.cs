using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtonControls : MonoBehaviour {

    public Button LT_button;
    public Button fireTruck_button;
    public Button Plane_button;
    public Button earthMoving_button;

    public GameObject LT_panel;
    public GameObject fireTruck_panel;
    public GameObject plane_panel;
    public GameObject earthMoving_panel;

    public bool LT_stats;
    public bool fireTruck_stats;
    public bool plane_stats;
    public bool earthMoving_stats;

    void Awake()
    {
        LT_panel.gameObject.SetActive(false);
        fireTruck_panel.gameObject.SetActive(false);
        plane_panel.gameObject.SetActive(false);
        earthMoving_panel.SetActive(false);
    }

    // Use this for initialization
    void Start ()
    {
        Button btn_LT = LT_button.GetComponent<Button>();
        btn_LT.onClick.AddListener(PanelForLT);

        Button btn_fireTruck = fireTruck_button.GetComponent<Button>();
        btn_fireTruck.onClick.AddListener(PanelForfireTruck);

        Button btn_Plane = Plane_button.GetComponent<Button>();
        btn_Plane.onClick.AddListener(PanelForPlane);

        Button btn_EarthMovering = earthMoving_button.GetComponent<Button>();
        btn_EarthMovering.onClick.AddListener(PanelForearthMoving);



    }
	
	// Update is called once per frame
	void Update () {
		
	}

    void PanelForLT()
    {
        LT_stats = true;
        
        LT_panel.gameObject.SetActive(true);

        if (fireTruck_stats == true)
        {
            fireTruck_panel.gameObject.SetActive(false);
        }
        if (plane_stats == true)
        {
            plane_panel.gameObject.SetActive(false);
        }
        if (earthMoving_stats == true)
        {
            earthMoving_panel.SetActive(false);
        }
    }

    void PanelForfireTruck()
    {
        fireTruck_stats = true;
        fireTruck_panel.gameObject.SetActive(true);
        if(LT_stats == true)
        {
            LT_panel.gameObject.SetActive(false);
        }
        if (plane_stats == true)
        {
            plane_panel.gameObject.SetActive(false);
        }
        if (earthMoving_stats == true)
        {
            earthMoving_panel.SetActive(false);
        }
    }

    void PanelForPlane()
    {
        plane_stats = true;
        plane_panel.gameObject.SetActive(true);
        if (LT_stats == true)
        {
            LT_panel.gameObject.SetActive(false);
        }
       
        if (earthMoving_stats == true)
        {
            earthMoving_panel.SetActive(false);
        }
        if (fireTruck_stats == true)
        {
            fireTruck_panel.gameObject.SetActive(false);
        }
    }

    void PanelForearthMoving()
    {
        earthMoving_stats = true;
        earthMoving_panel.SetActive(true);

        if (LT_stats == true)
        {
            LT_panel.gameObject.SetActive(false);
        }

        if (fireTruck_stats == true)
        {
            fireTruck_panel.gameObject.SetActive(false);
        }
        if (plane_stats == true)
        {
            plane_panel.gameObject.SetActive(false);
        }
    }
}
