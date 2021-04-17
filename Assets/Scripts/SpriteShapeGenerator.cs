using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.U2D;

public class SpriteShapeGenerator : MonoBehaviour {
    [SerializeField] private SpriteShapeController spriteShape;
    [SerializeField] private EdgeCollider2D _collider;

    public void GenerateShape(float[] heights) {
        var spline = spriteShape.spline;
        spline.Clear();

        int i = 0;
        for (i = 0; i < heights.Length; i++) {
            spline.InsertPointAt(i, new Vector3(i * 2, heights[i], 0));
            
            if (i == heights.Length - 1 || i == 0) {
                spline.SetTangentMode(i, ShapeTangentMode.Linear);
                continue;
            }
            
            spline.SetTangentMode(i, ShapeTangentMode.Broken);
            spline.SetLeftTangent(i, new Vector3(-1, 0, 0));
            spline.SetRightTangent(i, new Vector3(1, 0, 0));
        }
        
        spline.InsertPointAt(i, new Vector3((i - 1) * 2, -5, 0));
        spline.SetTangentMode(i, ShapeTangentMode.Linear);
        spline.InsertPointAt(i + 1, new Vector3(0, -5, 0));
        spline.SetTangentMode(i + 1, ShapeTangentMode.Linear);
        
        // spriteShape.RefreshSpriteShape();
        // spriteShape.UpdateSpriteShapeParameters();
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

    private void LateUpdate() {
        // spriteShape.BakeMesh();
        // spriteShape.BakeCollider();
    }

    private float[] GenerateHeights() {
        return new float[] {
            0, 0, 0, 0, 1, 2, 3, 2, 1, 1, 1, 0, 3, 4, 3, 2, 1, 0, 1, 0,
        };
    }
}