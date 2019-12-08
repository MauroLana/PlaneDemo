using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Simple script to simulate proppeller rotation
public class ProppellerRotation : MonoBehaviour
{
    //roration speed can be tweaked in the inspector
    public float rotationSpeed;

    void FixedUpdate()
    {
        this.transform.Rotate(0, rotationSpeed, 0, Space.Self);
    }
}
