using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    Rigidbody rb;

    public float speed;
    public float spinForce;

    //This is the parent object of the Main Camera
    public Transform camPivot;
    //For horizontal rotation
    float heading;
    //For vertical rotation
    float heading2;
    //Direct reference to the camera
    public Transform cam;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        float h = Input.GetAxis("Horizontal");
        float v = Input.GetAxis("Vertical");

        //Mouse input
        float mouseX = Input.GetAxis("Mouse X");
        float mouseY = Input.GetAxis("Mouse Y");

        //Apply the X rotation
        //Using either mouseX or inputX 
        heading += (mouseX) * Time.deltaTime * 180;
        heading2 += (mouseY) * Time.deltaTime * 180;

        Vector3 movement = new Vector3(h, 0.0f, v);
        rb.velocity = movement * speed;
    }

    void FixedUpdate()
    {
        //Jump is mapped to space bar, just making it easy to remember
        if(Input.GetButton("Jump"))
        {
            rb.AddTorque(0.0f, spinForce, 0.0f);
        }
    }
}
