using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraLookAround : MonoBehaviour {

    public float panSpeed = 4f;
    public float panBorderThickness = 10f;


    public Vector2 panLimit;


    void Update()
    {
        Vector3 pos = transform.position;

        if(Input.GetKey("w") || Input.mousePosition.y >= Screen.height - panBorderThickness )
        {
            pos.z += panSpeed * Time.deltaTime;
        }
        if (Input.GetKey("s") || Input.mousePosition.y <= panBorderThickness)
        {
            pos.z -= panSpeed * Time.deltaTime;
        }
        if (Input.GetKey("d") || Input.mousePosition.x >= Screen.width - panBorderThickness)
        {
            pos.x += panSpeed * Time.deltaTime;
        }
        if (Input.GetKey("a") || Input.mousePosition.x <= panBorderThickness)
        {
            pos.x -= panSpeed * Time.deltaTime;
        }
       
     
        pos.x = Mathf.Clamp(pos.x, 20f, 29.01922f);

        pos.z = Mathf.Clamp(pos.z, 9.9f, 39.35721f);
        transform.position = pos;
    }


}