using UnityEngine;
using System.Collections;
using System.Collections.Generic;

[DisallowMultipleComponent]
[RequireComponent(typeof(AddForce))]
public class BallPhysics : MonoBehaviour
{
    private AddForce addForce;
    private List<Vector3> forceList = new List<Vector3>();
    public float mass;
    public Vector3 ballVelocity;
    public Vector3 netForce;
    public bool showTrails;
    private LineRenderer lineR;
    private Vector3 acc;

    void Start()
    {
        addForce = GetComponent<AddForce>();
        lineR = gameObject.AddComponent<LineRenderer>();
        lineR.startWidth = 0.2f;
        lineR.endWidth = 0.2f;
        lineR.material = new Material(Shader.Find("Sprites/Default"));
        lineR.material.color = Color.red;
        lineR.useWorldSpace = false;
    }

    void FixedUpdate()
    {
        lineR.enabled = showTrails;
        AddForce();
        if (showTrails)
        {
            DrawLine();
        }
        transform.position += ballVelocity;
    }

    void AddForce()
    {
        netForce += addForce.ForceAdd() * Time.deltaTime;
        acc = netForce / mass;
        ballVelocity += acc * Time.deltaTime;
    }

    void DrawLine()
    {
        forceList = addForce.GetForceList();
        lineR.positionCount = forceList.Count * 2;
        int i = 0;
        foreach (Vector3 forceVector in forceList)
        {
            lineR.SetPosition(i, Vector3.zero);
            lineR.SetPosition(i + 1, forceVector);
            i = i + 2;
        }
    }
}
