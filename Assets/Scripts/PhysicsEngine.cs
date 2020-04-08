using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PhysicsEngine : MonoBehaviour
{
    public Vector3 ballVelocity;
    public Vector3 netForce;
    public List<Vector3> forceList = new List<Vector3>();

    void FixedUpdate()
    {
        AddForce();
        if (netForce == Vector3.zero)
        {
            transform.position += ballVelocity * Time.deltaTime;
        }
        else
        {
            Debug.LogError("Unbalanced net Force !");
        }
    }

    void AddForce()
    {
        foreach (var force in forceList)
        {
            netForce += force;
        }
    }
}
