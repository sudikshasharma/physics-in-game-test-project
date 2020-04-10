using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AddForce : MonoBehaviour
{
    public List<Vector3> forceList = new List<Vector3>();

    void FixedUpdate()
    {
        ForceAdd();
    }

    public Vector3 ForceAdd()
    {
        Vector3 netForce = Vector3.zero;
        foreach (var force in forceList)
        {
            netForce += force;
        }
        return netForce;
    }

    public List<Vector3> GetForceList()
    {
        return forceList;
    }
}
