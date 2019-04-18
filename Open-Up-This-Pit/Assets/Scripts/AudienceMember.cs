using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudienceMember : MonoBehaviour
{
    public Rigidbody rb;
    public bool grounded;
    public int band;

    public float rotationSpeed = 10f;

    Quaternion currentRotation;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        band = Random.Range(0, 8);
    }

    // Update is called once per frame
    void Update()
    {   
        Vector3 audioVector = new Vector3(AudioPeer._audioBandBuffer[band], AudioPeer._audioBandBuffer[band], AudioPeer._audioBandBuffer[band]) * rotationSpeed;
        transform.Rotate(audioVector);
    }
    
}
