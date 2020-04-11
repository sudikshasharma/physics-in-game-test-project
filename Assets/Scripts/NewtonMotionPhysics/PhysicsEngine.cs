using UnityEngine;
using System.Collections.Generic;
using UnityEngine.SceneManagement;

public class PhysicsEngine : MonoBehaviour
{
    public Vector3 ballVelocity;
    public Vector3 netForce;
    public float mass = 10f;
    public List<Vector3> forceVectorList = new List<Vector3>();

    void FixedUpdate()
    {
        AddForce();
        if (netForce == Vector3.zero)
        {
            transform.position += ballVelocity * Time.deltaTime;
        }
        else
        {
            Debug.Log("Unbalanced Net Force !");
        }
        if (SceneManager.GetActiveScene().name == "NewtonSecondLaw")
        {
            UpdateVelocity();
        }
    }

    void AddForce()
    {
        foreach (var force in forceVectorList)
        {
            netForce += force;
        }
    }

    void UpdateVelocity()
    {
        Vector3 acceleration = netForce / mass;
        ballVelocity += acceleration * Time.deltaTime;
    }
}
