using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class AirResist : MonoBehaviour
{
    [Range(1, 2)]
    public float velocityExponent; //As per stroke's law , between 1 and 2
    public float formulaConstant;
    private ObjectBody objectBody;

    void Start()
    {
        objectBody = GetComponent<ObjectBody>();
    }
    void FixedUpdate()
    {
        objectBody.AddForce(-(objectBody.objectVelocity.normalized * formulaConstant * Mathf.Pow(objectBody.objectVelocity.magnitude, velocityExponent)));
    }
}
