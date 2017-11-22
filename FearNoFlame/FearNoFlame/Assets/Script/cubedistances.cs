using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cubedistances : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        Debug.Log(Vector3.Distance(Camera.main.transform.position , this.transform.position));
	}
}
