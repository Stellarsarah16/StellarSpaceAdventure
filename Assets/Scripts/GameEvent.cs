using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameEvent : MonoBehaviour {

    public event EventHandler HaulButtonPressed;
    public event EventHandler HaulButtonReleased;

    private void Update() {
        if (Input.GetKeyDown(KeyCode.Q)) {
            HaulButtonPressed?.Invoke(this, EventArgs.Empty);
        }
        if (Input.GetKeyUp(KeyCode.Q)) {
            HaulButtonReleased?.Invoke(this, EventArgs.Empty);
        }
    }
}
