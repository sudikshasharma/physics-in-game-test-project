using UnityEngine;

public class ObjectBody : MonoBehaviour
{
    public float objectMass;
    public Vector3 objectVelocity;
    public Vector3 totalForce;
    private Vector3 acc;

    void FixedUpdate()
    {
        acc = totalForce / objectMass;
        objectVelocity += acc;
        transform.position += objectVelocity;
        RenderTrail();
    }

    void RenderTrail()
    {
        //Code to draw force lines on object
    }

    public void AddForce(Vector3 force)
    {
        totalForce += force;
    }
}
