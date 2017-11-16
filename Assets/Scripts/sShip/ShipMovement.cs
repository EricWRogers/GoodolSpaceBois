using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShipMovement : MonoBehaviour {
    [SerializeField] float movementSpeed = 50f;
    [SerializeField] float turnSpeed = 60f;
    private bool isMoving = false;
    private float acceleration = 0.0f;
    private float speed = 0.0f;
    private float maxSpeed = 2.0f;

    Transform myT;
	void Awake () {
        myT = transform;
	}
	
	// Update is called once per frame
	void Update () {
        Turn();
        Thrust();
	}

    void Turn()
    {
        if(isMoving)
        {
            //float yaw = turnSpeed * Time.deltaTime * Input.GetAxis("Horizontal");
            float pitch = (turnSpeed * speed) * Time.deltaTime * Input.GetAxis("Vertical");
            float roll = (turnSpeed * speed) * Time.deltaTime * Input.GetAxis("Horizontal");
            myT.Rotate(pitch, 0, roll);
        }
    }
    void Thrust()
    {
        if (Input.GetAxis("Axis1D.SecondaryIndexTrigger") > 0 && Input.GetAxis("Axis1D.SecondaryIndexTrigger") > speed)
        {
            speed = Input.GetAxis("Axis1D.SecondaryIndexTrigger");
        }
        if(speed > 0 || Input.GetAxis("Axis1D.SecondaryIndexTrigger") == 0)
        {
            speed = speed - 0.1f * Time.deltaTime;
        }

        if(speed > 0)
        {
            myT.position += myT.forward * movementSpeed * Time.deltaTime * speed;
            isMoving = true;
        }
        else
        {
            isMoving = false;
        }
    }
}
