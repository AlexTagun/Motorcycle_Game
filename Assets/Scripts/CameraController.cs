using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour {
    [SerializeField] private Transform motorcycleTransform;

    private void Update() {
        transform.position = new Vector3(motorcycleTransform.position.x, 1, -10);
    }
}