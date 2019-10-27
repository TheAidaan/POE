using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    public float panSpeed = 20f;  // speed we move camera
    public float panBorderThickness = 10f;
    public Vector2 panLimit;  //limits the amount we can pan on the x and y
    public float scrollSpeed = 20f;
    public float minY = 20f;
    public float maxY = 120f;

    
    void Update()
    {

        Vector3 pos = transform.position;
        //getting inputs to control camera
        if (Input.GetKey("w"))
        {
            pos.z += panSpeed * Time.deltaTime;
        }

        if (Input.GetKey("s"))
        {
            pos.z -= panSpeed * Time.deltaTime;
        }
        if (Input.GetKey("a"))
        {
            pos.x -= panSpeed * Time.deltaTime;
        }
        if (Input.GetKey("d"))
        {
            pos.x += panSpeed * Time.deltaTime;
        }

        float scroll = Input.GetAxis("Mouse ScrollWheel");
        pos.y -= scroll * scrollSpeed * 100f *  Time.deltaTime;

        pos.x = Mathf.Clamp(pos.x, -panLimit.x, panLimit.x);    //limiting the amount we can pan side to side and up and down
        pos.y = Mathf.Clamp(pos.y, minY, maxY);
        pos.z = Mathf.Clamp(pos.z, -panLimit.y, panLimit.y);

        transform.position = pos;

    }
}
