using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AutoRotate : MonoBehaviour
{
    
    private Vector3 _rotationSpeed = new(0, 100, 0); // Rotation speed in degrees per second for each axis (X, Y, Z)

    void Update()
    {
        // Rotate the object based on the rotationSpeed and deltaTime
        transform.Rotate(_rotationSpeed * Time.deltaTime);
        
    }
}
