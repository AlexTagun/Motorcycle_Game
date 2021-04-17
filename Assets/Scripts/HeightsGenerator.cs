using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeightsGenerator {
    private float _curHeight = 0;
    private List<float> _heights = new List<float>();

    public float[] Generate(int count) {
        _heights.Clear();
        
        for (int i = 0; i < count; i++) {
            _heights.Add(_curHeight);

            if(i == count - 1) break;
            
            _curHeight += Random.value > 0.5f ? 1 : -1;
            if (_curHeight < 0) _curHeight = 0;
        }

        return _heights.ToArray();
    }
}