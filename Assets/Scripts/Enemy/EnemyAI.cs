using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAI : MonoBehaviour {

    private Vector3 startingPosition;

    void Start() {
        startingPosition = transform.position;
    }

    private Vector3 GetRoamingPosition() {
        return startingPosition + GetRandomDir() * Random.Range(10f, 70f);
    }
    
    public static Vector3 GetRandomDir() {
        return new Vector3(Random.Range(-1f,-1f), Random.Range(-1f,1f)).normalized;
    }
}
