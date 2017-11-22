using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PutOutFireHelitack : MonoBehaviour {

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
        grounds[0].GetComponent<CellBehaviour>().IsonFire = false;
        grounds[1].GetComponent<CellBehaviour>().IsonFire = false;
        grounds[2].GetComponent<CellBehaviour>().IsonFire = false;
        grounds[3].GetComponent<CellBehaviour>().IsonFire = false;
        grounds[4].GetComponent<CellBehaviour>().IsonFire = false;
        grounds[5].GetComponent<CellBehaviour>().IsonFire = false;
        grounds[6].GetComponent<CellBehaviour>().IsonFire = false;

    }
}
