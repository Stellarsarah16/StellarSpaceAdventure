using System.Collections;
using UnityEngine;
using System;
using UnityEngine.Events;

//Version using Actions

public class HaulCargo : MonoBehaviour {

    [SerializeField] private GameObject player;
    public event EventHandler EnterHaulRange;
    public event EventHandler ExitHaulRange;

    public void OnTriggerEnter2D(Collider2D collision) {
        Debug.Log(collision.name);

        //  Bug, collision is giving me the player tag instead of cargo.


        if (collision.transform.root.CompareTag("Cargo")) {
            EnterHaulRange?.Invoke(this, EventArgs.Empty);
            Debug.Log("triggerEnter");
        }
    }

    public void OnTriggerExit2D(Collider2D collision) {
        if (collision.transform.root.CompareTag("Cargo")) {
            ExitHaulRange?.Invoke(this, EventArgs.Empty);
            Debug.Log("triggerExit");
        }
    }
}
