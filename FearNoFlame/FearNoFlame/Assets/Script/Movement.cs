using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class Movement : MonoBehaviour
{
    public UnitSelection Uss;

    public GameObject selectedGameObjectlol;

    public Vector3 targetPosition;
    void Awake()
    {
        Uss = GetComponent<UnitSelection>();
    }



    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        selectedGameObjectlol = Uss.SelectedPlayer;
        SecondCast();

        if (Input.GetMouseButtonDown(1))
        {
            selectedGameObjectlol = null;


        }

        

    }

    

    void SecondCast()
    {
        if (Input.GetMouseButtonDown(0))
        {
            
            RaycastHit endpoint;
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

            if (Physics.Raycast(ray, out endpoint))
            {
                if (Uss.SelectedPlayer != null)
                {
                    targetPosition = new Vector3 (endpoint.point.x, 0.51f, endpoint.point.z);
                    Uss.SelectedPlayer.transform.position = targetPosition;
                   
                }

              
            }
        }
      

        



    }


  

}

        

    


   



