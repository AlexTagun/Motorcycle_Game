using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TerrainGenerator : MonoBehaviour {
    [SerializeField] private SpriteShapeGenerator A;
    [SerializeField] private SpriteShapeGenerator B;

    private readonly HeightsGenerator _heightsGenerator = new HeightsGenerator();
    
    private int _heightsCount = 20;

    private void Start() {
        A.GenerateShape(_heightsGenerator.Generate(_heightsCount));
        GenerateNextSpriteShape();
    }

    private void GenerateNextSpriteShape() {
        bool isALast = A.transform.position.x > B.transform.position.x;
        SpriteShapeGenerator lastShape = isALast ? A : B;
        SpriteShapeGenerator firstShape = !isALast ? A : B;

        Vector3 newPosition = new Vector3(lastShape.transform.position.x + 38, 0, 0);
        firstShape.transform.position = newPosition;
        transform.position = newPosition + new Vector3(19, 0, 0);
        
        firstShape.GenerateShape(_heightsGenerator.Generate(_heightsCount));
    }

    private void OnTriggerEnter2D(Collider2D other) {
        GenerateNextSpriteShape();
    }
}