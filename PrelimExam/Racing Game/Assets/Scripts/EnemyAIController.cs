using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAIController : MonoBehaviour
{

    public Transform Path;
    private List<Transform> waypoint;

    public int curPoint = 0;
    private float newSteer;
    public float maxSteerAngle = 55f;
    public Vector3 centerOfMass; // center of mass
    public float maxMotorTorque = 80f;

    public WheelCollider flWheel, frWheel; // front left and right wheel colliders

    // Start is called before the first frame update
    void Start()
    {
        GetComponent<Rigidbody>().centerOfMass = centerOfMass; // when turning the car doesn't flip too much

        // makes a waypoint system using parent-child relationship
        Transform[] pathTransform = Path.GetComponentsInChildren<Transform>();
        waypoint = new List<Transform>();

        // gets the index for each child in the waypoint system
        for(int i = 0; i < pathTransform.Length; i++)
        {
            // checks if pathTransform of current waypoint is not equal to current transform
            if (pathTransform[i] != Path.transform)
            {
                waypoint.Add(pathTransform[i]); // pushes to waypoint list
            }
        }

    }

    // for horizontal movements of the car
    void ApplySteer()
    {
        Vector3 relativeVector = transform.InverseTransformPoint(waypoint[curPoint].position);
        newSteer = (relativeVector.x / relativeVector.magnitude) * maxSteerAngle;
        flWheel.steerAngle = newSteer;
        frWheel.steerAngle = newSteer;
    }

    // for vertical movements of the car
    void Movement()
    {
        flWheel.motorTorque = maxMotorTorque;
        frWheel.motorTorque = maxMotorTorque;
    }

    void CheckWayPointDist()
    {
        // checks if the car is near the next waypoint line
        if (Vector3.Distance(transform.position, waypoint[curPoint].position) < 0.5f)
        {
            // if current waypoint is at the last point
            if (curPoint == waypoint.Count - 1)
            {
                curPoint = 0;
            }
            else
            {
                curPoint ++;
            }
        }
    }

    // FixedUpdate is best used when applying physics related functions 
    void FixedUpdate()
    {
        ApplySteer();
        Movement();
        CheckWayPointDist();
    }
}
