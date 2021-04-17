using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class UiDistance : MonoBehaviour {
    [SerializeField] private TextMeshProUGUI _text;
    [SerializeField] private Transform motorcycle;
    
    private float _startPosition;

    private void Start() {
        _startPosition = motorcycle.position.x;
    }

    private void Update() {
        int dif = Mathf.RoundToInt(motorcycle.position.x - _startPosition);
        if (dif < 0) dif = 0;
        _text.text = dif.ToString();
    }
}