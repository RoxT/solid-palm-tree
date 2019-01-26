using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tenticle : MonoBehaviour {

    private HingeJoint joint;
    private JointMotor motor;
    private int collisionDebounce = 0;

	// Use this for initialization
	void Start () {

        joint = GetComponent<HingeJoint>();
        motor = joint.motor;

    }
	
	// Update is called once per frame
	void Update () {
		if (collisionDebounce > 0)
        {
            collisionDebounce--;
        }
	}

    private void OnCollision(Collision collision)
    {
            JointMotor motor = joint.motor;
            Debug.Log("1. targetVelocity : " + motor.targetVelocity);
            motor.targetVelocity = -joint.motor.targetVelocity;
            joint.motor = motor;
            collisionDebounce = 10;
            Debug.Log("2. targetVelocity : " + motor.targetVelocity);
    }

    private void OnCollisionStay(Collision collision)
    {
        if (collisionDebounce <= 0)
        {
            JointMotor motor = joint.motor;
            Debug.Log("1. targetVelocity : " + motor.targetVelocity);
            motor.targetVelocity = -joint.motor.targetVelocity;
            joint.motor = motor;
            collisionDebounce = 10;
            Debug.Log("2. targetVelocity : " + motor.targetVelocity);
        }

    }
}
