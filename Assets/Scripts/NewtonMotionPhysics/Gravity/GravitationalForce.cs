using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GravitationalForce : MonoBehaviour
{
    private GravitationalForce[] objects;
    private LineRenderer lineR;
    private Vector3 acc;
    private float bigG = 6.673e-11f;
    public Vector3 totalForce;
    public Vector3 objSpeed;
    public float objectMass;

    void Start()
    {
        objects = GameObject.FindObjectsOfType<GravitationalForce>();
        lineR = gameObject.AddComponent<LineRenderer>();
        lineR.useWorldSpace = false;
    }

    void FixedUpdate()
    {
        CalculateNetForce();
        transform.position += objSpeed;
    }
    void CalculateNetForce()
    {
        foreach (var objectA in objects)
        {
            int i = 1;
            foreach (var objectB in objects)
            {
                if (objectA != objectB)
                {
                    Vector3 force = (objectA.transform.position - objectB.transform.position).normalized * (bigG * objectA.objectMass * objectB.objectMass / Mathf.Pow((objectA.transform.position - objectB.transform.position).magnitude, 2));
                    RenderForceLines(force, i);
                    AddForce(force);
                    i += 2;
                }
            }
        }
    }

    void RenderForceLines(Vector3 force, int i)
    {
        lineR.positionCount += i;
        lineR.startWidth = 0.2f;
        lineR.endWidth = 0.2f;
        lineR.material = new Material(Shader.Find("Sprites/Default"));
        lineR.material.color = Color.red;
        lineR.SetPosition(i, Vector3.zero);
        lineR.SetPosition(i + 1, force.normalized);
    }

    public void AddForce(Vector3 force)
    {
        totalForce += force;
        acc = totalForce / objectMass;
        Debug.Log(acc);
        objSpeed += acc;
    }
}
