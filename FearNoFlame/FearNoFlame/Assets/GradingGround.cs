using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GradingGround : MonoBehaviour {

	public List<GameObject> grounds;

	// Use this for initialization
	void Start ()
	{
		grounds = new List<GameObject>();
		
	}
	
	// Update is called once per frame
	void Update () {
		
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
				grounds [i].GetComponent<Renderer> ().material.color = Color.white;
				grounds [i].GetComponent<CellBehaviour> ().FireDangerIndex = 0;
                grounds[i].GetComponent<CellBehaviour>().enviromentalMakeUp = 0;
			}
		}

		grounds.Remove (other.gameObject);
	}
}
