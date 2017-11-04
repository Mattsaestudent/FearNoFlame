using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class UnitSelection : MonoBehaviour {

    public GameObject highlightedPlayer;
    public GameObject SelectedPlayer;

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

        RaycastHit hitInfo;

        if (Physics.Raycast(ray, out hitInfo))
        {
            if (hitInfo.transform.tag != "terrain")
            {

                GameObject hitObject = hitInfo.transform.root.gameObject;

                SelectObject(hitObject);
            }
            else
            {
                ClearSelection();
                return;
            }
        }
      

        if (Input.GetMouseButtonDown(1))
        {
            SelectedPlayer = highlightedPlayer;

           if(SelectedPlayer == highlightedPlayer)
            {
                SelectedPlayer.GetComponent<Renderer>().sharedMaterial.color = Color.blue;
            }


        }
      

          
                
          
            
        
    }

    void SelectObject(GameObject obj)
    {
        if (highlightedPlayer != null)
        {
            if (obj == highlightedPlayer)
                return;

            ClearSelection();
        }

        highlightedPlayer = obj;

        Renderer[] rs = highlightedPlayer.GetComponentsInChildren<Renderer>();
        foreach (Renderer r in rs)
        {
            Material m = r.material;
            m.color = Color.green;
            r.material = m;
        }


    }

    void ClearSelection()
    {
        if (highlightedPlayer == null)
            return;

        Renderer[] rs = highlightedPlayer.GetComponentsInChildren<Renderer>();
        foreach (Renderer r in rs)
        {
            Material m = r.material;
            m.color = Color.white;
            r.material = m;
        }


        highlightedPlayer = null;
       
    }
}
