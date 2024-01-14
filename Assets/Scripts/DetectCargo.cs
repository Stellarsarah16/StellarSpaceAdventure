using System.Collections;
using UnityEngine;
using System;


//Version using Actions

public class DetectCargo : MonoBehaviour {

    public event EventHandler EnterHaulRange;
    public event EventHandler ExitHaulRange;

    public void OnTriggerEnter2D(Collider2D collision) {

        if (collision.transform.root.CompareTag("Cargo")) {
            EnterHaulRange?.Invoke(this, EventArgs.Empty);
        }
    }

    public void OnTriggerExit2D(Collider2D collision) {
        if (collision.transform.root.CompareTag("Cargo")) {
            ExitHaulRange?.Invoke(this, EventArgs.Empty);
        }
    }
}
