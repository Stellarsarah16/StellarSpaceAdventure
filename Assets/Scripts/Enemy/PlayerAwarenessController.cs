using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAwarenessController : MonoBehaviour {

    public bool AwareOfPlayer { get; private set; }
    public Vector2 DirectionToPlayer { get; private set; }

    [SerializeField]
    private float _playerAwarenessDistance;
    private Transform _player;

    private void Awake() {
        _player = FindObjectOfType<PlayerController>().transform;
    }



    void Update() {
        Vector2 enemyToPlayerVector = _player.position - transform.position;
        DirectionToPlayer = enemyToPlayerVector.normalized;
        if (enemyToPlayerVector.magnitude <= _playerAwarenessDistance &&
            _player.GetComponent<HealthController>().RemainingHealthPercentage != 0) {
            AwareOfPlayer = true;
        } else {
            AwareOfPlayer = false;
        }
    }
}
