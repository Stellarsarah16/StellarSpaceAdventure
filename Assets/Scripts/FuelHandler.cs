using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FuelHandler {

    public event EventHandler OnAddFuel;

    private List<Fuel> fuelList;

    public FuelHandler(int fuelAmount) { 
        fuelList = new List<Fuel>();
        for (int i = 0; i < fuelAmount; i++) {
            Fuel fuel = new Fuel(4);
            fuelList.Add(fuel);
        }
    }

    public List<Fuel> GetFuelList() {
        return fuelList;
    }

    public void AddFuel(int fuelAmount) {
        //cycle through all fuel starting from end
        /*
        for (int i = fuelList.Count-1; i >= 0; i--) {
            Fuel fuel = fuelList[i];
            //test if fuel can be absorbed
            if (fuelAmount > fuel.GetFragmentAmount()) {
                fuelAmount -= fuel.GetFragmentAmount();
                fuel.AddFuel(fuel.GetFragmentAmount());
            } else {
                fuel.AddFuel(fuelAmount);
                break;
            }
        }*/
        for (int i = 0; i < fuelAmount; i++) {
            Fuel fuel = fuelList[i];
            if (fuelAmount > fuel.GetFragmentAmount()) {
                fuelAmount += fuel.GetFragmentAmount();
                fuel.AddFuel(fuel.GetFragmentAmount());
            } else {
                fuel.AddFuel(fuelAmount);
            }
        }

        OnAddFuel?.Invoke(this, EventArgs.Empty);
    }

    public class Fuel {

        private int fragments;

        public Fuel(int fragments) {
            this.fragments = fragments;
        }

        public int GetFragmentAmount() { return fragments; }

        public void SetFragments(int fragments) {
            this.fragments= fragments;
        }

        public void AddFuel(int fuelAmount) {
            if (fuelAmount >= fragments) {
                fragments = 0;
            } else {
                fragments -= fuelAmount;
            }
        }
    }


}
