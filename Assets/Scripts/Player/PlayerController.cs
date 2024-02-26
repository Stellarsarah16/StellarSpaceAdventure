using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour {

    [SerializeField]
    private float _speed, _rotationSpeed;

    private Rigidbody2D _rigidbody;
    [SerializeField] private GameInput gameInput;
    private Vector2 _turningInput;
    private float _rotationAngle;
    private bool _isThrusting;


    private void Awake() {
        _rigidbody = GetComponent<Rigidbody2D>();
        _rotationAngle = 0f;
    }

    private void Update() {
        _turningInput = gameInput.GetTurningVector();
        _isThrusting = gameInput.GetThrustInput();

    }

    private void FixedUpdate() {
        MovePlayer();
        RotatePlayer();
    }

    private void MovePlayer() {
        if (_isThrusting) {
            Debug.Log(_isThrusting);
            _rigidbody.AddForce(transform.up *_speed);
        }
    }

    private void RotatePlayer() {
        if (_turningInput != Vector2.zero) {
            Debug.Log(_turningInput.x);
            _rotationAngle -= _turningInput.x * _rotationSpeed;
            _rigidbody.MoveRotation(_rotationAngle);
        }
    }

}

