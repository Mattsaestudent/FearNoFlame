using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraLookAround : MonoBehaviour {

    public float panSpeed = 20f;
    public float panBorderThickness = 5f;


    public Vector2 panLimit;

    public bool isup;
    public bool isdown;
    public bool isleft;
    public bool isrigh;

    void Start()
    {
        isup = false;
        isdown = false;
        isleft = false;
        isrigh = false;
    }


    void Update()
    {
        Vector3 pos = transform.position;

        if(Input.GetKey("w") || Input.mousePosition.y >= Screen.height - panBorderThickness )
        {
            pos.z += panSpeed * Time.deltaTime;
            isup = true;
        }
        if (Input.GetKey("s") || Input.mousePosition.y <= panBorderThickness)
        {
            pos.z -= panSpeed * Time.deltaTime;
            isdown = true;

        }
        if (Input.GetKey("d") || Input.mousePosition.x >= Screen.width - panBorderThickness)
        {
            pos.x += panSpeed * Time.deltaTime;
            isrigh = true;
        }
        if (Input.GetKey("a") || Input.mousePosition.x <= panBorderThickness)
        {
            pos.x -= panSpeed * Time.deltaTime;
            isleft = true;
        }
       
     
        pos.x = Mathf.Clamp(pos.x, 20f, 29.01922f);

        pos.z = Mathf.Clamp(pos.z, 9.9f, 39.35721f);
        transform.position = pos;
    }


}