using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Item Collection")]
public class ItemCollection : ScriptableObject {

    public event Action Changed;

    List<Cargo> collectedItems = new List<Cargo>();

    public int Count => collectedItems.Count;

    public void Add(Cargo item) {
        collectedItems.Add(item);
        Changed?.Invoke();
        
    }

}
