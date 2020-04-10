using UnityEngine;

public class RocketPhysics : MonoBehaviour
{
    [Range(0, 1)]
    public float fuelConsumptionPercentage;
    public float fuelAmount;
    public float maxForce;
    public float currentForce;
    public Vector3 forceDirection;
    private ObjectBody objectBody;

    void Start()
    {
        objectBody = GetComponent<ObjectBody>();
        objectBody.objectMass += fuelAmount;
    }
    void FixedUpdate()
    {
        if (fuelAmount > FuelBurn())
        {
            fuelAmount -= FuelBurn();
            objectBody.objectMass -= FuelBurn();
            CalculateForce();
        }
        else
        {
            print("Out of Fuel !");
        }
    }
    float FuelBurn()
    {
        float velocityExpression = 2100f;   //Of rocket Googled from internet
        return currentForce / velocityExpression;
    }
    void CalculateForce()
    {
        currentForce = maxForce * 1000 * fuelConsumptionPercentage;
        objectBody.AddForce(currentForce * forceDirection.normalized);
    }
}
