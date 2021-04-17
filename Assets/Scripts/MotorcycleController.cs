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
#if UNITY_EDITOR
        _movement = Input.GetAxis("Horizontal");
        return;
#endif
        if(Input.touchCount < 1) return;

        bool isRightSideClick = Input.touches[0].position.x > Screen.width / (float) 2;

        _movement = isRightSideClick ? 1 : 0;

    }

    private void FixedUpdate() {
        _motor.maxMotorTorque = 999999999;
        _motor.motorSpeed = _movement * speed;
        backWheel.motor = _motor;
        frontWheel.motor = _motor;
    }
}