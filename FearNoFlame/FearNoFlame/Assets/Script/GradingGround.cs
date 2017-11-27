using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GradingGround : MonoBehaviour {

	public List<GameObject> grounds;

    public int movementNumber;
    public bool donotmove;
    public UnitSelection unitSelection;
    public Movement movement;
	// Use this for initialization
	void Start ()
	{
		grounds = new List<GameObject>();
        movementNumber = 0;
        donotmove = false;

        unitSelection = GameObject.Find("Selection").GetComponent<UnitSelection>();
        movement = GameObject.Find("Selection").GetComponent<Movement>();
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
                else
                {
                    unitSelection.highlightedPlayer = unitSelection.SelectedPlayer;
                    unitSelection.SelectedPlayer = movement.selectedGameObjectlol;
                }
            }
        }

        if (movementNumber >= 360)
        {
            donotmove = true;
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
				grounds [i].GetComponent<Renderer> ().material.color = Color.black;
				grounds [i].GetComponent<CellBehaviour> ().FireDangerIndex = 0;
                grounds[i].GetComponent<CellBehaviour>().enviromentalMakeUp = 0;
			}
		}

		grounds.Remove (other.gameObject);
        movementNumber += 1;

        

	}

    float AngleBetweenPoints(Vector2 a, Vector2 b)
    {
        return Mathf.Atan2(a.y - b.y, a.x - b.x) * Mathf.Rad2Deg;
    }
}
