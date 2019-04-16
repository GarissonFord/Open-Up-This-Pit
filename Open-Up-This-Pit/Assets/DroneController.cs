using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DroneController : MonoBehaviour
{
    Rigidbody rb;
    public float h, v;
    public float speed;

    public float mouseX, mouseY;
    float heading, heading2;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>(); 
    }

    // Update is called once per frame
    void Update()
    {
        h = Input.GetAxis("Horizontal");
        v = Input.GetAxis("Vertical");

        mouseX = Input.GetAxis("Mouse X");
        mouseY = -Input.GetAxis("Mouse Y");

        //Vector3 movement = new Vector3(h, 0.0f, v);
        Vector3 movement = transform.right * h + transform.forward * v;
        rb.velocity = movement * speed;

        //Apply the X rotation
        heading += (mouseX) * Time.deltaTime * 180;
        heading2 += (mouseY) * Time.deltaTime * 180;

        transform.rotation = Quaternion.Euler(heading2, heading, 0);
    }
}
