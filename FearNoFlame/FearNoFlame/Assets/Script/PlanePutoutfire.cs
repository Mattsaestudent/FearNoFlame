using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlanePutoutfire : MonoBehaviour {

    public List<GameObject> grounds;

    public List<GameObject> listofcells;

    public bool fireinrang;

    // Use this for initialization
    void Start()
    {
        grounds = new List<GameObject>();
        listofcells = new List<GameObject>();

    }

    // Update is called once per frame
    void Update()
    {
        if (grounds != null)
        {
            return;
        }




    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "terrain")
        {

            if (other.gameObject.GetComponent<CellBehaviour>().IsonFire == true)
            {
                if (!grounds.Contains(other.gameObject))
                    grounds.Add(other.gameObject);
            }
        }

    }

    void OnTriggerExit(Collider other)
    {
        grounds.Remove(other.gameObject);
    }

    public void CheckforFire()
    {
        for (int i = 0; i < grounds.Count; i++)
        {
            grounds[i].GetComponent<CellBehaviour>().IsonFire = false;
           
        }


    }
}
