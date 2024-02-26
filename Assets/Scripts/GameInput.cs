using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class GameInput : MonoBehaviour {

    private PlayerInputActions playerInputActions;
    public event EventHandler HaulButtonPressed;
    public event EventHandler FireButtonPressed;

    private void Awake() {
        playerInputActions = new PlayerInputActions();
        playerInputActions.Player.Enable();

        playerInputActions.Player.Haul.performed += Haul_performed;
        playerInputActions.Player.Fire.performed += Fire_performed;
    }

    private void Fire_performed(UnityEngine.InputSystem.InputAction.CallbackContext obj) {
        FireButtonPressed?.Invoke(this, EventArgs.Empty );
    }

    private void Haul_performed(UnityEngine.InputSystem.InputAction.CallbackContext obj) {
        HaulButtonPressed?.Invoke(this, EventArgs.Empty);
    }

    public Vector2 GetTurningVector() {
        Vector2 inputVector = playerInputActions.Player.Turn.ReadValue<Vector2>();
        return inputVector;
    }

    bool toggle;
    public bool GetThrustInput() {
        bool isThrusting = playerInputActions.Player.Thrust.triggered;
        if (toggle) {
            toggle = false; isThrusting = false;
        } else toggle = isThrusting;

        return toggle;
    }
}
