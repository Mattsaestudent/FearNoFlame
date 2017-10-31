using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class Movement : MonoBehaviour
{

    public CellBehaviour cb;

    public bool selectedCell;

    public List<GameObject> cellstoMove;


    public GameObject first;
    public GameObject secondselect;

    public Vector3 nextPoint;
    public Vector3 theendpoint;
    public Vector3 startPoint;

    [HideInInspector] public GameObject[] titles;

    void Awake()
    {
        titles = GameObject.FindGameObjectsWithTag("terrain");

    }



    // Use this for initialization
    void Start()
    {

        cellstoMove = new List<GameObject>();
        HighlighList();


    }

    // Update is called once per frame
    void Update()
    {
        
        SecondCast();

        

        maths();

    }

    void HighlighList()
    {
        RaycastHit hit;

        RaycastHit[] hitCombos;

        

        
        

        if (Physics.Raycast(transform.position, -Vector3.up, out hit,400.0f))
        {

            if (hit.transform.tag == "terrain")
            {
                cellstoMove.Add(hit.transform.gameObject);
                startPoint = hit.transform.position;
            }
        }

        


    }

    void SecondCast()
    {
        if (Input.GetMouseButtonDown(1))
        {
            
            RaycastHit endpoint;
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            if (Physics.Raycast(ray, out endpoint, 400.0f))
            {
                
                secondselect = endpoint.transform.gameObject;
                theendpoint = endpoint.transform.position;


            }
        }
        //  theendpoint = secondselect.transform.position;
        var index = System.Array.IndexOf(titles, cellstoMove[0]);


        startPoint = titles[index].transform.position;

        //cellstoMove.Add(cb.GM.);

        



        Debug.Log(index);
    }


    void maths()
    {
        nextPoint = theendpoint-startPoint;

      
    }

}

        

    


   



