using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TerrainGenerator : MonoBehaviour {
    [SerializeField] private int heightsCount = 20;
    [SerializeField] private int cellWidth = 2;
    
    [SerializeField] private SpriteShapeGenerator A;
    [SerializeField] private SpriteShapeGenerator B;

    private readonly HeightsGenerator _heightsGenerator = new HeightsGenerator();
    
    

    private void Start() {
        A.SetData(cellWidth);
        B.SetData(cellWidth);
        
        A.GenerateShape(_heightsGenerator.Generate(heightsCount));
        GenerateNextSpriteShape();
    }

    private void GenerateNextSpriteShape() {
        bool isALast = A.transform.position.x > B.transform.position.x;
        SpriteShapeGenerator lastShape = isALast ? A : B;
        SpriteShapeGenerator firstShape = !isALast ? A : B;
        
        float shapeWidth = cellWidth * (heightsCount - 1);

        Vector3 newPosition = new Vector3(lastShape.transform.position.x + shapeWidth, 0, 0);
        firstShape.transform.position = newPosition;
        transform.position = newPosition + new Vector3(shapeWidth / 2, 0, 0);
        
        firstShape.GenerateShape(_heightsGenerator.Generate(heightsCount));
    }

    private void OnTriggerEnter2D(Collider2D other) {
        GenerateNextSpriteShape();
    }
}