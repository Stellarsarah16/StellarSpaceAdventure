using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour {

    private Camera _camera;

    public event EventHandler BulletHit;

    [SerializeField]
    private float _damage = 5;

    private void Awake() {
        _camera = Camera.main;
    }

    private void Update() {
        DestroyWhenOffscreen();
    }

    private void OnTriggerEnter2D(Collider2D collision) {

        if(collision.gameObject.layer == 7) {
            // add new BulletHit event stuff here
            Destroy(gameObject);
            if (collision.GetComponent<EnemyMovement>()) {
                Destroy(collision.gameObject);
            }
            if (collision.GetComponent<Meteor>()) {
                Destroy(collision.gameObject);
            }
        }
    }

    private void DestroyWhenOffscreen() {
        Vector2 screenPosition = _camera.WorldToScreenPoint(transform.position);

        if (screenPosition.x < 0 ||
            screenPosition.x > _camera.pixelWidth ||
            screenPosition.y < 0 ||
            screenPosition.y > _camera.pixelHeight) {
            Destroy(gameObject);
        }
    }

}
