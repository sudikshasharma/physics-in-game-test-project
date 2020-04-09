using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class RocketEngine : MonoBehaviour
{
    private RocketBody rocketBody;
    [Range(0, 1)]
    public float fuelUtilizePercentage;
    public float fuelMass;
    public float maxThrust;
    public float currentThrust;
    public Vector3 thurstDirection;

    void Start()
    {
        rocketBody = GetComponent<RocketBody>();
        rocketBody.mass += fuelMass;
    }

    void FixedUpdate()
    {
        if (fuelMass > FuelConsume())
        {
            fuelMass -= FuelConsume();
            rocketBody.mass -= FuelConsume();
            ExertForce();
        }
        else
        {
            Debug.LogWarning("No Fuel Left !");
        }
    }

    float FuelConsume()
    {
        float exhaustVel = 4432f;
        float massConsumed = currentThrust / exhaustVel;
        return massConsumed * Time.deltaTime;
    }

    void ExertForce()
    {
        currentThrust = maxThrust * fuelUtilizePercentage * 1000f;
        rocketBody.AddForce(thurstDirection.normalized * currentThrust);
    }
}
