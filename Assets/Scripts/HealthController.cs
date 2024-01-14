using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthController : MonoBehaviour {

    public event EventHandler OnTakeDamage;
    public event EventHandler OnDamaged;
    public event EventHandler OnReceiveHealth;
    public event EventHandler OnDeath;


    [SerializeField]
    private float _currentHealth;
    [SerializeField]
    private float _maximumHealth;

    public float RemainingHealthPercentage {
        get { return _currentHealth / _maximumHealth; }
    }
    public bool IsInvincible { get; set; }

    public void TakeDamage(float damageAmount) {

        if (IsInvincible) {
            return;
        }

        _currentHealth -= damageAmount;

        OnTakeDamage.Invoke(this, EventArgs.Empty);

        if (_currentHealth < 0) {
            _currentHealth = 0;
        }
        if (_currentHealth == 0) {
            OnDeath?.Invoke(this, EventArgs.Empty);
        } else {
            OnDamaged.Invoke(this, EventArgs.Empty);
        }
    }

    public void AddHealth(float amountToAdd) {
        if (_currentHealth == _maximumHealth) { 
            return;
        }
        _currentHealth += amountToAdd;
        OnReceiveHealth.Invoke(this, EventArgs.Empty);
        if (_currentHealth > _maximumHealth) {
            _currentHealth = _maximumHealth;
        }
    }
}
