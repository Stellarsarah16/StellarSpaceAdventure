using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour {

    [SerializeField]
    public Transform player;
    [SerializeField]
    private float smoothingTime = 0.2f, zPosition = -10;
    private Vector3 velocity = Vector3.zero;


    private void Update() {
        if (player != null) {

            Vector3 targetPos = new Vector3 (player.position.x, player.position.y, -10);
            //Vector2 delta = targetPos - transform.position;

            //Camera Position
            //transform.position = new Vector3(player.position.x, player.position.y, zPosition);
            transform.position = Vector3.SmoothDamp(transform.position, targetPos, ref velocity, smoothingTime);

            // Camera Rotation
            // Quaternion rotation = transform.rotation * player.rotation;
            // transform.Rotate(player.eulerAngles, 10.0f * Time.deltaTime);


        }
    }
}
