using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameOverScript : MonoBehaviour
{

    public List<GameObject> grounds;

    public bool isGameEnded;

    void Awake()
    {
        grounds = new List<GameObject>();
        isGameEnded = false;
    }

    // Use this for initialization
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        CheckFire();
      
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "terrain")
        {
            grounds.Add(other.gameObject);
        }
    }

    void CheckFire()
    {
        for(int i = 0; i < grounds.Count; i++)
        {
           if(grounds[i].GetComponent<CellBehaviour>().IsonFire == true)
            {
                
                isGameEnded = true;
            }
        }
    }
}
