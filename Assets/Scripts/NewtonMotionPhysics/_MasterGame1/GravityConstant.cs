using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class GravityConstant : MonoBehaviour
{
    private float bigG = 6.67430e-11f;
    public ObjectBody[] objects;
    void Start()
    {
        objects = GameObject.FindObjectsOfType<ObjectBody>();
    }

    void FixedUpdate()
    {
        CalculateGravity();
    }

    void CalculateGravity()
    {
        foreach (var objectA in objects)
        {
            foreach (var objectB in objects)
            {
                if (objectA != objectB)
                {
                    Vector3 force = (objectA.transform.position - objectB.transform.position).normalized * (bigG * objectA.objectMass * objectB.objectMass / Mathf.Pow((objectA.transform.position - objectB.transform.position).magnitude, 2));
                    objectA.AddForce(-force);
                }
            }
        }
    }
}
