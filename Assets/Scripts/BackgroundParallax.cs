using System;
using UnityEngine;

public class BackgroundParallax : MonoBehaviour {
    [SerializeField] 
    private GameObject _player;

    private float _lengthX, _startPositionX, _lengthY, _startPositionY;
    [SerializeField]
    private float _parallaxFactor;



    void Start() {
        _startPositionX = transform.position.x;
        _startPositionY = transform.position.y;
        _lengthX = GetComponent<SpriteRenderer>().bounds.size.x;
        _lengthY = GetComponent<SpriteRenderer>().bounds.size.y;
    }

    
    void Update() {
        float distanceX = _player.transform.position.x * _parallaxFactor * 0.05f;
        float distanceY = _player.transform.position.y * _parallaxFactor * 0.05f;
        Vector3 newPosition = new Vector3(
            _startPositionX + distanceX,
            _startPositionY + distanceY, 
            transform.position.z
            );
        transform.position = newPosition;
    }
}
