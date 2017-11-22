using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PoolingObjects : MonoBehaviour {

    public List<GameObject> cellsinveiw;
    public GameObject anObject;
    public Collider anObjCollider;
    public Camera cam;
    private Plane[] planes;
	// Use this for initialization
	void Start ()
    {
        cellsinveiw = new List<GameObject>();
        cam = Camera.main;
        planes = GeometryUtility.CalculateFrustumPlanes(cam);
        anObjCollider = GetComponent<Collider>();
	}
	
	// Update is called once per frame
	void Update ()
    {
        if(GeometryUtility.TestPlanesAABB(planes,anObjCollider.bounds))
        {
            cellsinveiw.Add(anObject);
        }
        else
        {
            cellsinveiw.Remove(anObject);
        }
		
	}

    
}
