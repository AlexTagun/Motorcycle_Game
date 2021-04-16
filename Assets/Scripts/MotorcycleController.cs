using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MotorcycleController : MonoBehaviour {
    [SerializeField] private WheelJoint2D backWheel; 
    [SerializeField] private WheelJoint2D frontWheel;
    [SerializeField] private float speed;

    private JointMotor2D _motor;
    private float _movement;

    private void Update() {
        _movement = Input.GetAxis("Horizontal");
    }

    private void FixedUpdate() {
        _motor.maxMotorTorque = 999999999;
        _motor.motorSpeed = _movement * speed;
        backWheel.motor = _motor;
        frontWheel.motor = _motor;
    }
}