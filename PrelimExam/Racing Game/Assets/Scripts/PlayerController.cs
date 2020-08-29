using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{
    // axis names set in Unity settings
    private const string VERTICAL = "Vertical";
    private const string HORIZONTAL = "Horizontal";

    public Rigidbody rb;

    // Center of mass
    private Vector3 centerOfMass;

    //gets user input for movement
    private float horizontalInput;
    private float verticalInput;

    // variables needed for the movement of the car
    private float curSteerAngle;
    private bool isTurbo;

	public float motorForce;
    public float breakForce;
    public float maxSteerAngle;

    // wheel colliders
    public WheelCollider flCollider, frCollider;
    public WheelCollider rlCollider, rrCollider;

    // wheel transforms
    public Transform flWheel, frWheel;
    public Transform rlWheel, rrWheel;

    // condition to finish the race
    private bool reachedCheckpoint = false;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        rb.centerOfMass = centerOfMass; // when turning the car doesn't flip
    }

    // setting the movement of the car
    void GetInput()
    {
        verticalInput = Input.GetAxis(VERTICAL); // for up and down
        horizontalInput = Input.GetAxis(HORIZONTAL); // for left and right
        isTurbo = Input.GetKey(KeyCode.Space); // for speeding up the car
    }

    // movement of the car vertically
    void Movement()
    {
        flCollider.motorTorque = verticalInput * motorForce;
        frCollider.motorTorque = verticalInput * motorForce;
        if (isTurbo) // if [Space] is held
        {
            
        }
    }

    // movement of the car horizontally
    void Steering()
    {
        curSteerAngle = maxSteerAngle * horizontalInput;
        // only the front wheels are affected
        flCollider.steerAngle = curSteerAngle;
        frCollider.steerAngle = curSteerAngle;
    }

    // updates wheel visuals for every single wheel
    void UpdateWheels()
    {
        // takes the parameter from the UpdateWheelPose method
        UpdateWheelPose(flCollider, flWheel);
        UpdateWheelPose(frCollider, frWheel);
        UpdateWheelPose(rlCollider, rlWheel);
        UpdateWheelPose(rrCollider, rrWheel);
    }

    // get the position and rotation to be applied to the wheel transform
    void UpdateWheelPose(WheelCollider wheelCollider, Transform wheelTransform)
    {
        Vector3 pos;
        Quaternion rot;
        wheelCollider.GetWorldPose(out pos, out rot); // takes Vector3 and Quaternion as parameters
        wheelTransform.rotation = rot;
        wheelTransform.position = pos;
    }

    // function of car collision
    void OnTriggerEnter(Collider col)
    {
        // if car collides with finish line object
        if (col.gameObject.name == "FinishLine")
        {
            // if reachedCheckpoint is true
            if (reachedCheckpoint)
            {
                SceneManager.LoadScene("ScoreMenu");
                //GameObject.Find("Player").SendMessage("Finish");
            }
            
        }
        // if car collides with checkpoint object
        else if (col.gameObject.name == "Checkpoint")
        {
            Debug.Log("Checkpoint reached!");
            reachedCheckpoint = true;
        }
        
        
    }


    // FixedUpdate is used when applying physics related functions 
    void FixedUpdate()
    {
        GetInput();
        Movement();
        Steering();
        UpdateWheels();
    }
}
