using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour {

    public GameObject target;
    public float depth = -10;
    [SerializeField]
    private float smoothingTime = 0.3f;
    private Vector3 velocity = Vector3.zero;


    private void Update() {
        if (target != null) {
            Vector2 delta = transform.position - target.transform.position;
            transform.position = Vector3.SmoothDamp(transform.position, delta, ref velocity, smoothingTime);
        }
    }
}
