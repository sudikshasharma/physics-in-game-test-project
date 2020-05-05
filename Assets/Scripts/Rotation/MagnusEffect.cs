using UnityEngine;
using System.Collections;
using System.Collections.Generic;

[RequireComponent(typeof(Rigidbody))]
public class MagnusEffect : MonoBehaviour
{
    public Vector3 velocity;
    public Vector3 angularVelocity;
    public float magnusConstant;
    void Start()
    {
        gameObject.GetComponent<Rigidbody>().velocity = velocity;
        gameObject.GetComponent<Rigidbody>().angularVelocity = angularVelocity;
    }

    void Update()
    {
        // Add magnus force 
        gameObject.GetComponent<Rigidbody>().AddForce(magnusConstant * Vector3.Cross(velocity, angularVelocity));
    }
}
