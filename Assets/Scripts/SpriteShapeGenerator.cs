using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.U2D;

public class SpriteShapeGenerator : MonoBehaviour {
    [SerializeField] private SpriteShapeController spriteShape;
    [SerializeField] private EdgeCollider2D _collider;

    private float _cellWidth;
    public void SetData(float cellWidth) {
        _cellWidth = cellWidth;
    }

    public void GenerateShape(float[] heights) {
        var spline = spriteShape.spline;
        spline.Clear();

        int i = 0;
        for (i = 0; i < heights.Length; i++) {
            spline.InsertPointAt(i, new Vector3(i * _cellWidth + 0.01f, heights[i], 0));
            
            if (i == heights.Length - 1 || i == 0) {
                spline.SetTangentMode(i, ShapeTangentMode.Linear);
                continue;
            }
            
            spline.SetTangentMode(i, ShapeTangentMode.Broken);
            spline.SetLeftTangent(i, new Vector3(-1, 0, 0));
            spline.SetRightTangent(i, new Vector3(1, 0, 0));
        }
        
        spline.InsertPointAt(i, new Vector3((i - 1) * _cellWidth, -5, 0));
        spline.SetTangentMode(i, ShapeTangentMode.Linear);
        spline.InsertPointAt(i + 1, new Vector3(0, -5, 0));
        spline.SetTangentMode(i + 1, ShapeTangentMode.Linear);
        
        spriteShape.BakeMesh();
        spriteShape.BakeCollider();
        
        // var list = new List<Vector2>();
        //
        // for (i = 0; i < spline.GetPointCount(); i++) {
        //     list.Add(spline.GetPosition(i));
        // }
        //
        // _collider.points = list.ToArray();
    }
}