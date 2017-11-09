using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class UnitSelection : MonoBehaviour {

    public GameObject highlightedPlayer;
    public GameObject SelectedPlayer;

    public Movement move;

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
				if (hitInfo.transform.tag != "ICV") {

					GameObject hitObject = hitInfo.transform.root.gameObject;

					SelectObject (hitObject);
				}
            }
            else
            {
                ClearSelection();
                return;
            }
            if (Input.GetMouseButtonDown(0))
            {
                SelectedPlayer = highlightedPlayer;
            }


        }
      

        if (Input.GetMouseButtonDown(1))
        {
            SelectedPlayer = null;
            highlightedPlayer = null;

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
