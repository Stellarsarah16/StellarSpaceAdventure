using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapSystem : MonoBehaviour {
    
    void Start() {
        Mesh mesh = new Mesh();
        GetComponent<MeshFilter>().mesh = mesh;
    }

}
