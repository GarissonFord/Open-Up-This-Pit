using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudienceManager : MonoBehaviour
{
    //This script is only really used at the start of the scene to populate the environment

    public int audienceSize;
    //Limits of the x-coordinate of an audience member, y will always be 1
    public float xMin, xMax, yMin, yMax, zMin, zMax;

    public GameObject audienceMember;

    void Start()
    {
        SetupStage();
    }

    public void SetupStage()
    {
        for(int i = 1; i < audienceSize; i++)
        {
            Vector3 spawnLocation = new Vector3(Random.Range(xMin, xMax), Random.Range(yMin, yMax), Random.Range(zMin, zMax));
            Instantiate(audienceMember, spawnLocation, Quaternion.Euler(Vector3.zero));
        }
    }
}
