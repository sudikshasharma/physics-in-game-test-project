using UnityEngine;
using System.Collections;
using System.Collections.Generic;

[ExecuteInEditMode]
public class BasicRotation : MonoBehaviour
{
    Rigidbody rigidbody1;

    //here in unity, inertia tensor gives vec3, inertia to move around x,y and z axis
    //tensor in unity consider collider for geometry and not the mesh
    //if all the 3axis have different value, then rotation around the axis with middle value(out of x,y,z) will be unstable
    //no unstable rotation if all values of x,y,z are same or either 2 values are same.
    //we can deduce the unstanblity factor by the shape and symmetry of object.example, cube ,sphere and cylinder will have stable rotation but an object of shape of mobile phone(unsymmytric at all axis) will have unstable rotation around axis with median value
    //in unity, inertia is calculate considering the centre at centre of mass of object
    void OnEnable()
    {
        rigidbody1 = GetComponent<Rigidbody>();
        rigidbody1.angularVelocity = new Vector3(4, 0, 0);
        Debug.Log(rigidbody1.inertiaTensor);
    }
    void Update()
    {
        Debug.Log(rigidbody1.inertiaTensor);
    }
}
