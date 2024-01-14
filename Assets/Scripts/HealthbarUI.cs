using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthbarUI : MonoBehaviour {

    [SerializeField] private GameObject player;
    public Slider slider;

    void Start() {
        HealthController healthController = player.GetComponent<HealthController>();
        healthController.OnTakeDamage += HealthController_OnTakeDamage;
    }

    private void HealthController_OnTakeDamage(object sender, System.EventArgs e) {
        Debug.Log("player damaged");
        //Debug.Log(e);
    }

    public void SetMaxHealth(int health) {
        slider.maxValue = health;
        slider.value = health;
    }

    public void SetHealth(int health) {
        slider.value = health;
    }
    
}
