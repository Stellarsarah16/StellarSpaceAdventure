using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cargo : MonoBehaviour{

    [SerializeField] private GameObject gameEventObject;
    [SerializeField] private GameObject interact;
    [SerializeField] private GameObject rope;
    
    private HingeJoint2D joint;
    private bool canConnect;
    private bool isConnected;


    void Start () {
        // subscriber for Keypress
        GameEvent gameEvent = gameEventObject.AddComponent<GameEvent>();
        gameEvent.HaulButtonPressed += GameEvent_HaulButtonPressed;

        //subscriber for Haul Range
        DetectCargo detectCargo = interact.GetComponent<DetectCargo>();
        detectCargo.EnterHaulRange += DetectCargo_EnterHaulRange;
        detectCargo.ExitHaulRange += DetectCargo_ExitHaulRange;
     
        joint = GetComponent<HingeJoint2D>();
    }

    private void GameEvent_HaulButtonPressed(object sender, EventArgs e) {
        if(!isConnected) {
            if (canConnect) {
                isConnected = true;
                Debug.Log(isConnected);
                rope.active = true;
                joint.enabled = true;
            }
        } else {
            isConnected = false;
            Debug.Log(isConnected);
            joint.enabled = false;
            rope.active = false;
        }

    }

    private void DetectCargo_ExitHaulRange(object sender, EventArgs e) {
        Debug.Log("Exit");
        canConnect = false;
    }

    private void DetectCargo_EnterHaulRange(object sender, EventArgs e) {
        Debug.Log("Enter");
        canConnect = true;
    }

    public void StartHaul(bool isConnected) {
        Debug.Log("hauling");         
    }

    public void StopHaul() {
    }



}
