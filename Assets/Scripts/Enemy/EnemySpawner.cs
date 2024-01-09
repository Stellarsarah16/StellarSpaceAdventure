using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class EnemySpawner : MonoBehaviour {

    [SerializeField]
    private GameObject _enemyPrefab;
    [SerializeField]
    private float _minimumSpawnTime;
    [SerializeField]
    private float _maximumSpawnTime;

    private float _timeUntilSpawn;

    void Start() {
        SetTimeUntilSpawn();
    }

    
    void Update() {
        _timeUntilSpawn -= Time.deltaTime;

        if (_timeUntilSpawn <= 0) {
            Instantiate(_enemyPrefab, transform.position, Quaternion.identity);
            SetTimeUntilSpawn();
        }
    }

    private void SetTimeUntilSpawn() {
        _timeUntilSpawn = Random.Range(_minimumSpawnTime, _maximumSpawnTime);
    }
}
