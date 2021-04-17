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
    private bool _anyKeyPressed;

    private void Update() {
        _anyKeyPressed = false;
#if UNITY_EDITOR
        if (Input.GetKey(KeyCode.D)) {
            _movement = 1;
            _anyKeyPressed = true;
            return;
        }

        if (Input.GetKey(KeyCode.A)) {
            _movement = 0;
            _anyKeyPressed = true;
            return;
        }
        
        return;
#endif
        if(Input.touchCount < 1) return;

        bool isRightSideClick = Input.touches[0].position.x > Screen.width / (float) 2;
        _anyKeyPressed = true;
        _movement = isRightSideClick ? 1 : 0;

    }

    private void FixedUpdate() {
        backWheel.useMotor = _anyKeyPressed;
        frontWheel.useMotor = _anyKeyPressed;
        
        if(!_anyKeyPressed) return;
        
        _motor.maxMotorTorque = 999999999;
        _motor.motorSpeed = _movement * speed;
        backWheel.motor = _motor;
        frontWheel.motor = _motor;
    }
}