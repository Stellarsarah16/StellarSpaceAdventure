using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Meteor : MonoBehaviour {

    [SerializeField]
    private float _Health = 100;

    void Start() {
        
    }

    
    void Update() {
        
    }

    public void TakeDamage(float damage) {
        _Health -= damage;
    }
}
