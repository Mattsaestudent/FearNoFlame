using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PutoutFire24 : MonoBehaviour {

    public List<GameObject> grounds;

    public List<GameObject> listofcells;

    public bool fireinrang;

    // Use this for initialization
    void Start () {
        grounds = new List<GameObject>();
        listofcells = new List<GameObject>();

    }
	
	// Update is called once per frame
	void Update ()
    {
        
       

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
        grounds.Remove(other.gameObject);
    }

    void CheckforFire()
    {
            fireinrang = true;
            for (int i = 0; i == 0; i++)
            {
                listofcells[i].GetComponent<CellBehaviour>().IsonFire = false;
            }
        }
      
    
    
        


    }

