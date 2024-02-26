using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spitter : MonoBehaviour {

    [SerializeField]
    private GameObject _projectilePrefab;
    [SerializeField] private Bullet bullet;
    [SerializeField]
    private Transform _mouthOffset;
    public int health = 10;
    private int currentHealth;
    
    public Animator animator;

    private float lastTime, projectileSpeed = 2f;

    void Start () {
        currentHealth = health;
        bullet.BulletHit += Bullet_BulletHit;
    }

    private void Bullet_BulletHit(object sender, System.EventArgs e) {
        
    }

    void Update() {
        float shootDelay = Random.Range(1, 4);
        float timeSince = Time.time - lastTime;

        if (timeSince >= shootDelay) {
            Debug.Log(timeSince);
            animator.SetTrigger("IsSpitting");
            spitProjectile();
            lastTime = Time.time;
        }

        if (currentHealth  <= 0) {
            Destroy(gameObject);
        }
    }

    public void TakeDamage(int damage) {
        currentHealth -= damage;
    }

    private void spitProjectile() {

        GameObject projectile = Instantiate(_projectilePrefab, _mouthOffset.position, transform.rotation);
        Rigidbody2D rigidbody = projectile.GetComponent<Rigidbody2D>();

        rigidbody.velocity = projectileSpeed * transform.up;
    

    }
}
