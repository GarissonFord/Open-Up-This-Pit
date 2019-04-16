using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudienceMember : MonoBehaviour
{
    public Rigidbody rb;
    public bool grounded;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        //if grounded
             //if upright
             //if not upright
                  //move upright
        if(grounded)
        {
            ReturnToOriginalRotation();
        }
    }

    public void ReturnToOriginalRotation()
    {
        float abs = Mathf.Abs(Quaternion.Dot(rb.rotation, Quaternion.Euler(Vector3.zero)));
        if (abs >= 0.999f)
        {
            rb.angularVelocity = Vector3.zero;
            //rb.freezeRotation = true;
            //freezeTime = DateTime.Now;
            //ReturnReleased();
        }
        else
        {
            var target = Quaternion.Euler(Vector3.zero) * Quaternion.Inverse(rb.rotation);
            rb.AddTorque(target.x, target.y, target.z, ForceMode.VelocityChange);
        }
    }

    public void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
            grounded = true;
    }

    public void OnCollisionStay(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
            grounded = true;
    }

    public void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
            grounded = false;
    }
}
