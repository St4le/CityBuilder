//Hudson
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraControls : MonoBehaviour
{
    public float speed = 200f;
    public float shiftspeed = 250f;
    float camSens = 0.25f; //How sensitive it with mouse
    private Vector3 lastMouse = new Vector3(255, 255, 255);


    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.Mouse2))
        {
            lastMouse = Input.mousePosition - lastMouse;
            lastMouse = new Vector3(-lastMouse.y * camSens, lastMouse.x * camSens, 0);
            lastMouse = new Vector3(transform.eulerAngles.x + lastMouse.x, transform.eulerAngles.y + lastMouse.y, 0);
            transform.eulerAngles = lastMouse;
            lastMouse = Input.mousePosition;
        }
        float f = 0.0f;
        Vector3 p = GetBaseInput();
        if (Input.GetKey(KeyCode.LeftShift))
        {
            p = p * shiftspeed;

        }
        else
        {
            p = p * speed;
        }
        p = p * Time.deltaTime;
        Vector3 newPosition = transform.position;
        if (Input.GetKey(KeyCode.Space))
        { //If player wants to move on X and Z axis only
            transform.Translate(p);
            newPosition.x = transform.position.x;
            newPosition.z = transform.position.z;
            transform.position = newPosition;
        }
        else
        {
            transform.Translate(p);
        }
    }
    private Vector3 GetBaseInput()
    {
        Vector3 p_Velocity = new Vector3();
        if (Input.GetKey(KeyCode.W))
        {
            p_Velocity += new Vector3(0, 0, 1);
        }
        if (Input.GetKey(KeyCode.S))
        {
            p_Velocity += new Vector3(0, 0, -1);
        }
        if (Input.GetKey(KeyCode.A))
        {
            p_Velocity += new Vector3(-1, 0, 0);
        }
        if (Input.GetKey(KeyCode.D))
        {
            p_Velocity += new Vector3(1, 0, 0);
        }
        return p_Velocity;
    }
}
