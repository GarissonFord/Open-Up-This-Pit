using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    Rigidbody rb;

    public float speed;
    public float spinForce;

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
