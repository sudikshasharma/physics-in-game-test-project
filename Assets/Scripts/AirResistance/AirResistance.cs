using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class AirResistance : MonoBehaviour
{
    private GravitationalForce gravitationalForce;
    [Range(1, 2)]
    public float velExp;
    public float dragConstant;
    public float force;

    void Start()
    {
        gravitationalForce = GetComponent<GravitationalForce>();
    }

    void FixedUpdate()
    {
        gravitationalForce.AddForce(CalculateDrag(gravitationalForce.objSpeed.magnitude) * -(gravitationalForce.objSpeed.normalized));
    }

    float CalculateDrag(float velocity)
    {
        return (dragConstant * Mathf.Pow(velocity, velExp));
    }
}
