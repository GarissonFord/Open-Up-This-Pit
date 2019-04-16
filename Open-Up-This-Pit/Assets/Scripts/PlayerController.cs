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

    //Movement input
    Vector2 input;

    public Vector3 currentRotation;

    public float h, v;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    /*
    void Update()
    {
        float h = Input.GetAxis("Horizontal");
        float v = Input.GetAxis("Vertical");

        //Mouse input
        float mouseX = Input.GetAxis("Mouse X");
        float mouseY = Input.GetAxis("Mouse Y");

        //Apply the X rotation
        heading += (mouseX) * Time.deltaTime * 180;
        heading2 += (mouseY) * Time.deltaTime * 180;

        camPivot.rotation = Quaternion.Euler(heading2, heading, 0);


        Vector3 movement = new Vector3(h, 0.0f, v);
        rb.velocity = movement * speed;
    }
    */

    void Update()
    {
        //Mouse input
        float mouseX = Input.GetAxis("Mouse X");
        float mouseY = Input.GetAxis("Mouse Y");
        //Stick input
        float inputX = Input.GetAxis("Horizontal"), inputZ = Input.GetAxis("Vertical");
        //Apply the X rotation
        //Using either mouseX or inputX 
        heading += (mouseX + inputX) * Time.deltaTime * 180;
        heading2 += (mouseY + inputZ) * Time.deltaTime * 180;
        camPivot.rotation = Quaternion.Euler(heading2, heading, 0);

        h = Input.GetAxisRaw("Horizontal");
        v = Input.GetAxisRaw("Vertical");

        //If the player is moving at all
        /*
        if (h != 0 || v != 0)
            anim.SetBool("IsMoving", true);
        else if (h == 0 && v == 0)
            anim.SetBool("IsMoving", false);
            */

        Vector3 movement = new Vector3(inputX, 0.0f, inputZ);

        input = new Vector2(h, v);
        input = Vector2.ClampMagnitude(input, 1);

        Vector3 camF = cam.forward; //forward
        Vector3 camR = cam.right; //right

        //Because of the downward angle the camera is facing
        camF.y = 0;
        camR.y = 0;
        camF = camF.normalized;
        camR = camR.normalized;

        // v > 0 Means the player's input is to move forward

        if (v != 0)
        {
            //Sets rotation to the camera pivot's forward
            currentRotation = camPivot.eulerAngles;
            transform.eulerAngles = currentRotation;
        }

        //Walking backwards
        /*
        if (v < 0)
            anim.SetBool("MovingBackwards", true);
        else if (v >= 0)
            anim.SetBool("MovingBackwards", false);
            */

        //Final movement update
        transform.position += (camF * input.y + camR * input.x) * Time.deltaTime * 5;
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
