using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAIWheels : MonoBehaviour
{
    public WheelCollider targetwheel;

    // get the position and rotation to be applied to the wheel transform
    private Vector3 pos = new Vector3();
    private Quaternion rot = new Quaternion();

    // Update is called once per frame
    void Update()
    {
        targetwheel.GetWorldPose(out pos, out rot); // takes Vector3 and Quaternion as parameters
        transform.position = pos;
        transform.rotation = rot;
    }
}
