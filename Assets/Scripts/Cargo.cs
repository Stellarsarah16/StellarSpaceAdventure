using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cargo : MonoBehaviour{

    //Ship Door Interaction
    private void OnTriggerEnter2D(Collider2D other) {
      
        Debug.Log("test");
        if (other.TryGetComponent<PlayerSpawn>(out var shipDoor)) {
            gameObject.SetActive(false);
        }
        
    }
}
