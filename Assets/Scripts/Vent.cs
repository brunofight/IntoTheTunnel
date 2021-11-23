using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Vent : MonoBehaviour
{

    [SerializeField]
    private float RotationSpeed = 1.0f;

    
    void Update()
    {
        transform.RotateAround(transform.position, transform.forward, Time.deltaTime * 360f * RotationSpeed);
    }
}
