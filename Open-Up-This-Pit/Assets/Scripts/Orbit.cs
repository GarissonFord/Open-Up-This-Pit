using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Orbit : MonoBehaviour
{
    //obsolete
    public Vector3 origin;
    public Vector3 orbitDirection;
    public float orbitSpeed;
    public int directionIndicator;

    // Start is called before the first frame update
    void Start()
    {
        orbitSpeed = Random.Range(1.0f, 5.0f);
        origin = Vector3.zero;
        directionIndicator = Random.Range(0, 4);

        switch(directionIndicator)
        {
            case 0:
                orbitDirection = Vector3.up;
                break;
            case 1:
                orbitDirection = Vector3.down;
                break;
            case 2:
                orbitDirection = Vector3.left;
                break;
            case 3:
                orbitDirection = Vector3.right;
                break;
        }
    }

    // Update is called once per frame
    void Update()
    {
        transform.RotateAround(origin, orbitDirection, orbitSpeed * Time.deltaTime);
    }
}
