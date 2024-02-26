using System;
using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Tilemaps;

public class Bullet : MonoBehaviour {

    private Camera _camera;

    public event EventHandler BulletHit;

    [SerializeField]
    private int damage = 2;
    private float pushForce = 100f;

    private void Awake() {
        _camera = Camera.main;
    }

    private void Update() {
        DestroyWhenOffscreen();
    }

    private void OnTriggerEnter2D(Collider2D collision) {

        if(collision.gameObject.layer == 7 || collision.gameObject.layer == 8) {
            // add new BulletHit event stuff here
            Destroy(gameObject);
  
            if (collision.GetComponent<Meteor>()) {
                Destroy(collision.gameObject);
            }
            if (collision.gameObject.tag == "Enemy") {
                collision.gameObject.GetComponent<Spitter>().TakeDamage(damage);
            }
            if (collision.gameObject.tag == "Cargo") {
                Vector2 PushDirection = transform.position - collision.transform.position;
                collision.attachedRigidbody.AddForce(transform.up * pushForce);
            }
            if (collision.CompareTag("Breakable")) {
                Destroy(collision.gameObject);
            }
            
            BulletHit?.Invoke(this, EventArgs.Empty); 
        }
    }

    private void DestroyWhenOffscreen() {
        Vector2 screenPosition = _camera.WorldToScreenPoint(transform.position);

        if (screenPosition.x < -50 ||
            screenPosition.x > _camera.pixelWidth + 50 ||
            screenPosition.y < -50 ||
            screenPosition.y > _camera.pixelHeight + 50) {
            Destroy(gameObject);
        }
    }
}
