using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameRestarter : MonoBehaviour {
    private void OnCollisionEnter2D(Collision2D other) {
        if(!other.gameObject.name.StartsWith("shape")) return;
        
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}