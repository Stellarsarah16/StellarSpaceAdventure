
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour {


    [SerializeField]
    private float _speed, _rotationSpeed, _screenBorder = 15;

    private Rigidbody2D _rigidbody;

    private Camera _camera;

    //private PlayerAwarenessController _playerAwarenessController;
    private Vector2 _targetDirection;
    private float _changeDirectionCooldown;

    void Awake() {
        _rigidbody = GetComponent<Rigidbody2D>();
        //_playerAwarenessController = GetComponent<PlayerAwarenessController>();
        _targetDirection = transform.up;
        _camera = Camera.main;
    }
    
    void FixedUpdate() {
        UpdateTargetDirection();
        RotateTowardsTarget();
        SetVelocity();
        //print(_playerAwarenessController);
    }

    private void UpdateTargetDirection() {
        HandleRandomDirectionChange();
        HandlePlayerTargeting();
        HandleEnemyOffScreen();
    }

    private void HandleEnemyOffScreen() {
        Vector2 screenPosition = _camera.WorldToScreenPoint(transform.position);

        if ((screenPosition.x < _screenBorder && _targetDirection.x < 0) ||
            (screenPosition.x > _camera.pixelWidth - _screenBorder && _targetDirection.x > 0)) {
            _targetDirection = new Vector2(-_targetDirection.x, _rigidbody.velocity.y);
        }
        if ((screenPosition.y < _screenBorder && _targetDirection.y < 0) ||
            (screenPosition.y > _camera.pixelHeight - _screenBorder && _targetDirection.y > 0)) {
            _targetDirection = new Vector2(_rigidbody.velocity.x, -_targetDirection.y);
        }
    }

    private void HandlePlayerTargeting() {
       // if (_playerAwarenessController.AwareOfPlayer) {
       //     _targetDirection = _playerAwarenessController.DirectionToPlayer;
       // }
    }

    private void HandleRandomDirectionChange() {
        _changeDirectionCooldown -= Time.deltaTime;
        if (_changeDirectionCooldown <= 0) {
            float angleChange = Random.Range(-90f, 90f);
            Quaternion rotation = Quaternion.AngleAxis(angleChange, transform.forward);
            _targetDirection = rotation * _targetDirection;

            _changeDirectionCooldown = Random.Range(1f, 5f);
        }
    }

    private void SetVelocity() {
        _rigidbody.velocity = transform.up * _speed;
    }

    private void RotateTowardsTarget() {
        Quaternion targetRotation = Quaternion.LookRotation(transform.forward, _targetDirection);
        Quaternion rotation = Quaternion.RotateTowards(transform.rotation, targetRotation, _rotationSpeed * Time.deltaTime);

        _rigidbody.SetRotation(rotation);
    }
}
