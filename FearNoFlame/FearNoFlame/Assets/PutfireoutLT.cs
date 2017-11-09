using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PutfireoutLT : MonoBehaviour {

    public List<GameObject> grounds;

    public List<GameObject> getActiveCells;

   

    public bool fireinrang;

    // Use this for initialization
    void Start () {
        grounds = new List<GameObject>();

        getActiveCells = new List<GameObject>();


    }
	
	// Update is called once per frame
	void Update ()
    {

        

    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "terrain")
        {
           
            if (other.gameObject.GetComponent<CellBehaviour>().IsonFire == true)
            {
                grounds.Add(other.gameObject);
            }
        }
        



    }

    void OnTriggerExit(Collider other)
    {
        grounds.Remove(other.gameObject);
    }

   
        
     public void GetActive()
    {
        for(int i =0; i < grounds.Count; i++)
        {
            if (grounds != null)
            {
                getActiveCells.Add(grounds[i]);
            }
            else { Debug.Log("Grounds is null WTF"); }
        }
        
        
    }
       
        
    



}
