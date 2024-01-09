using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour {
    [SerializeField]
    private float _speed;

    [SerializeField]
    private float _rotationSpeed;

    private float _screenBorder = 14f;

    private Rigidbody2D _rigidbody;
    private Vector2 _movementInput;
    private Vector2 _smoothedMovementInput;
    private Vector2 _movementInputSmoothVelocity;
    private Camera _camera;

    private void Awake() {
        _rigidbody = GetComponent<Rigidbody2D>();
        _camera = Camera.main;
    }

    private void Update() {
        if (_camera != null) {
            CanFollow();
        }
    }

    private void FixedUpdate() {
        MovePlayer();
        //SetPlayerVelocity();
        RotateInDirectionOfInput();
    }

    private void MovePlayer() {
        _smoothedMovementInput = Vector2.SmoothDamp(
            _smoothedMovementInput,
            _movementInput,
            ref _movementInputSmoothVelocity,
            0.1f);

        _rigidbody.AddForce(_speed * _smoothedMovementInput);
    }

    private void SetPlayerVelocity() {
        _smoothedMovementInput = Vector2.SmoothDamp(
                    _smoothedMovementInput,
                    _movementInput,
                    ref _movementInputSmoothVelocity,
                    0.1f);

        _rigidbody.velocity = _smoothedMovementInput * _speed;
    }
    private void CanFollow() {
        _camera.transform.position = new Vector3(
             transform.position.x,
             transform.position.y,
             -10
             );
    }

    private void RotateInDirectionOfInput() {
        if (_movementInput != Vector2.zero) {
            Quaternion targetRotation = Quaternion.LookRotation(transform.forward, _smoothedMovementInput);

            Quaternion rotation = Quaternion.RotateTowards(transform.rotation, targetRotation, _rotationSpeed * Time.deltaTime);
            _rigidbody.MoveRotation(rotation);
        }
    }

    private void OnMove(InputValue inputValue) {
        _movementInput = inputValue.Get<Vector2>();
    }


}

