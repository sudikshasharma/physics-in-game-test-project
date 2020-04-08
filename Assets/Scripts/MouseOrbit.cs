using UnityEngine;

/// <summary>
/// A simple mouse orbit script that allows a camera to follow an object, rotate around it, and zoom in or out.
/// </summary>
[AddComponentMenu("Camera-Control/Mouse Orbit")]
public class MouseOrbit : MonoBehaviour
{
    /// <summary>
    /// The object this script is orbiting.
    /// </summary>
    public Transform target;

    /// <summary>
    /// The distance from the target.
    /// </summary>
    private float distance = 10.0f;

    /// <summary>
    /// The speed to rotate at, also known as sensitivity, in the X direction.
    /// </summary>
    private float xSpeed = 250.0f;

    /// <summary>
    /// The speed to rotate at, also known as sensitivity, in the Y direction.
    /// </summary>
    private float ySpeed = 120.0f;

    /// <summary>
    /// The minimum y angle to allow the camera to go to when rotating.
    /// </summary>
    private float yMinLimit = -20;

    /// <summary>
    /// The maximum y angle to allow the camera to go to when rotating.
    /// </summary>
    private float yMaxLimit = 80;

    /// <summary>
    /// the current x rotation of the camera.
    /// </summary>
    private float x = 0;

    /// <summary>
    /// The current y rotation of the camera.
    /// </summary>
    private float y = 0;

    /// <summary>
    /// This method intialized the MouseOrbit control and attaches it to the <see cref="target"/>.
    /// </summary>
    private void Start()
    {
        //Initialize the current angles to the camera's default angle.
        var angles = transform.eulerAngles;
        x = angles.y;
        y = angles.x;

        // Make the rigid body not change rotation
        if (GetComponent<Rigidbody>() != null) {
            GetComponent<Rigidbody>().freezeRotation = true;
        }
    }

    /// <summary>
    /// Handles input after all other updates occur. Will transform the attached GameObject based on mouse input.
    /// </summary>
    private void LateUpdate()
    {
        //If we have a valid target.
        if (target) {
            //Determine if we have any rotation change.
            x += Input.GetAxis("Mouse X") * xSpeed * 0.02f;
            y -= Input.GetAxis("Mouse Y") * ySpeed * 0.02f;

            //Get any zoom distance.
            distance += Input.mouseScrollDelta.y * 0.2f; // Line added

            //Clamp the Y rotation.
            y = ClampAngle(y, yMinLimit, yMaxLimit);

            //Calculate the new GameObject transform details.
            var rotation = Quaternion.Euler(y, x, 0);
            var position = rotation * new Vector3(0.0f, 0.0f, -distance) + target.position;

            //Set the GameObject's transform details.
            transform.rotation = rotation;
            transform.position = position;
        }
    }

    /// <summary>
    /// Handles clamping an angle between a minimum and maximum value to contrain an axis.
    /// </summary>
    /// <param name="angle">The angle to constrain, any number.</param>
    /// <param name="min">The minimum value to allow the angle to go to, any number smaller than max.</param>
    /// <param name="max">the maximum value to allow the angle to go tom, any number greater than min.</param>
    /// <returns>A float between <see cref="min"/> and <see cref="max"/>, or the original angle if between the two.</returns>
    public static float ClampAngle(float angle, float min, float max)
    {
        //Check if the angle is beyond a full positive or negative rotation and adjust.
        if (angle < -360)
            angle += 360;
        if (angle > 360)
            angle -= 360;

        //Restrict the angle to be between min and max.
        return Mathf.Clamp(angle, min, max);
    }
}