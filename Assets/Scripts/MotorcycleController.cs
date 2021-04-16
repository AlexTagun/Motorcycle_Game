using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MotorcycleController : MonoBehaviour {
    [SerializeField] private Rigidbody2D backWheel; 
    [SerializeField] private Rigidbody2D frontWheel;
    [SerializeField]private float speed;
    
    private float _movement;

    private void Update() {
        _movement = Input.GetAxis("Horizontal");
    }

    private void FixedUpdate() {
        backWheel.AddTorque(_movement * speed * Time.fixedDeltaTime);
        frontWheel.AddTorque(_movement * speed * Time.fixedDeltaTime);
    }
}