using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthController : MonoBehaviour {

    public event EventHandler OnTakeDamage;
    public event EventHandler OnReceiveHealth;
    public event EventHandler OnDeath;

    
    [SerializeField] private int health, maxHealth;
    
    public HealthController(int maxHealth) {
        this.maxHealth = maxHealth;
        health = maxHealth;
    }

    public int RemainingHealthPercentage {
        get { return health /maxHealth; }
    }

    public int GetHealth() { return health; }
    
    public bool IsInvincible { get; set; }

    
    public void TakeDamage(int damageAmount) {

        if (IsInvincible)  return;  

        health -= damageAmount;

        if (health < 0) health = 0;
        if (health == 0) {
            OnDeath?.Invoke(this, EventArgs.Empty);
        } else {
            OnTakeDamage.Invoke(this, EventArgs.Empty);
        }
    }

    public void AddHealth(int amountToAdd) {
        if (health == maxHealth) { 
            return;
        }
        health += amountToAdd;
        OnReceiveHealth.Invoke(this, EventArgs.Empty);
        if (health > maxHealth) {
            health = maxHealth;
        }
    }
}
