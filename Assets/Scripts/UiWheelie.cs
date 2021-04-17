using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UiWheelie : MonoBehaviour {
    [SerializeField] private CircleCollider2D backWheel;
    [SerializeField] private CircleCollider2D frontWheel;
    [SerializeField] private Collider2D terrainA;
    [SerializeField] private Collider2D terrainB;
    [SerializeField] private GameObject text;

    private float _fadeTime = 0.2f;
    private float _timeLeft = 0;

    private void Update() {
        if (backWheel.IsTouching(terrainA) && !frontWheel.IsTouching(terrainA)
            || backWheel.IsTouching(terrainB) && !frontWheel.IsTouching(terrainB)) {
            _timeLeft = _fadeTime;
        }
        
        text.SetActive(false);
        if(_timeLeft < 0) return;

        _timeLeft -= Time.deltaTime;

        text.SetActive(true);

    }
}