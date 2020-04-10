using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RocketBody : MonoBehaviour
{
    public float mass;
    public Vector3 currentVelocity;
    public Vector3 netForce;
    private Vector3 acc;

    void FixedUpdate()
    {
        transform.position = acc;
    }
    public void AddForce(Vector3 force)
    {
        acc = force / mass;
        currentVelocity += acc;
    }
}
