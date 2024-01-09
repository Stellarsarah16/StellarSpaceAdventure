using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cargo : MonoBehaviour{

    [SerializeField] private GameObject gameEventObject;
    [SerializeField] private GameObject _player;
    [SerializeField] private GameObject _anchor;

    private HingeJoint2D _joint;

    private bool canConnect;
    private bool isConnected;

    void Start () {

        // Haul Events
        // subscriber for Keypress
        GameEvents gameEvents = gameEventObject.GetComponent<GameEvents>();
        gameEvents.HaulButtonPressed += GameEvents_HaulButtonPressed;
        //subscriber for Haul Range
        HaulCargo haulCargo = gameEventObject.GetComponent<HaulCargo>();
        Debug.Log(gameEventObject);
        

        _joint = GetComponent<HingeJoint2D>();
    }

    private void GameEvents_HaulButtonPressed(object sender, EventArgs e) {
        
        Debug.Log("haulButtonPressed");

        if (canConnect) {
            Debug.Log("connected");
        }
    }

    public void StartHaul(bool isConnected) {
        Debug.Log("hauling");         
    }

    public void StopHaul() {
    }



}
