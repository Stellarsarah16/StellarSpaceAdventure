using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSpawn : MonoBehaviour {


    [SerializeField]
    private GameObject spawnPrefab;

    GameObject spawn;

    void Start () {
        SpawnPlayer();
    }

    private void SpawnPlayer() {
        spawn = Instantiate(spawnPrefab, transform.position, transform.rotation);
       
    }
    
}
