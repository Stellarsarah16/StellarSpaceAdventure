using System.Collections;
using UnityEngine;
using System;



//Version using Actions

public class DetectCargo : MonoBehaviour {

    [SerializeField] private GameObject rope;
    [SerializeField] private GameInput gameInput;

    private HingeJoint2D joint;

    private bool canConnect;
    private bool isConnected;

    void Start() {
        gameInput.HaulButtonPressed += GameInput_HaulButtonPressed;
    }

    private void GameInput_HaulButtonPressed(object sender, EventArgs e) {
        Debug.Log(canConnect);
        if (!isConnected) {
            if (canConnect) {
                isConnected = true;
                rope.SetActive(true);
                joint.enabled = true;
            }
        } else {
            isConnected = false;
            joint.enabled = false;
            rope.SetActive(false);
        }
    }

    public void OnTriggerEnter2D(Collider2D collision) {
        
        if (collision.transform.root.CompareTag("Cargo")) {
            joint = collision.gameObject.GetComponent<HingeJoint2D>();
            Debug.Log("in range");
            canConnect = true;
        }
    }

    public void OnTriggerExit2D(Collider2D collision) {
        if (collision.transform.root.CompareTag("Cargo")) {
            joint = collision.gameObject.GetComponent<HingeJoint2D>();
            Debug.Log("not in range");
            canConnect = false;
        }
    }
}
