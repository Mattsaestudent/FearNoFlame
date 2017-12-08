using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GradingGround : MonoBehaviour {

	public List<GameObject> grounds;

    public int movementNumber;
    public bool donotmove;
    public UnitSelection unitSelection;
    public Movement movement;
    public Material ground;

    Collider m_Collider;
    Rigidbody rb;

    // Use this for initialization

    void Awake()
    {
        unitSelection = GameObject.Find("Selection").GetComponent<UnitSelection>();
        movement = GameObject.Find("Selection").GetComponent<Movement>();
        donotmove = false;
    }
    void Start ()
	{
		grounds = new List<GameObject>();
        movementNumber = 0;
        m_Collider = GetComponent<Collider>();


    }

    // Update is called once per frame
    void Update()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

        RaycastHit hitInfo;

        if (Physics.Raycast(ray, out hitInfo))
        {
            if (hitInfo.transform.tag == "dozer")
            {
                if (donotmove == true)
                {
                    unitSelection.highlightedPlayer = null;
                    unitSelection.SelectedPlayer = null;
                    
                }
              
            }
        }

        if (movementNumber >= 167)
        {
            donotmove = true;

            m_Collider.enabled = !m_Collider.enabled;
            unitSelection.enabled = !unitSelection.enabled;
            movement.enabled = !movement.enabled;



        }
        else
        {
            donotmove = false;
          
        }


    }
    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "terrain")
        {
            grounds.Add(other.gameObject);
        }
    }


    void OnTriggerExit(Collider other)
	{
		if (other.gameObject.tag == "terrain") {
			for (int i = 0; i < grounds.Count; i++) {
				grounds [i].GetComponent<Renderer> ().material= ground;
				grounds [i].GetComponent<CellBehaviour> ().FireDangerIndex = 0;
                grounds[i].GetComponent<CellBehaviour>().enviromentalMakeUp = 0;
			}
		}

		grounds.Remove (other.gameObject);
        movementNumber += 1;

        

	}

   
}
