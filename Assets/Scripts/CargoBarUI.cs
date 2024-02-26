using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CargoBarUI : MonoBehaviour {

    [SerializeField] private Sprite bar0Sprite;
    [SerializeField] private Sprite bar1Sprite;
    [SerializeField] private Sprite bar2Sprite;
    [SerializeField] private Sprite bar3Sprite;
    [SerializeField] private Sprite bar4Sprite;

    private List<BarImage> barImageList;
    private FuelHandler fuelHandler;

    private void Awake() {
        barImageList = new List<BarImage>();
    }

    private void Start() {
        FuelHandler fuelHandler = new FuelHandler(2);
        SetFuelHandler(fuelHandler);
    }

    public void SetFuelHandler(FuelHandler fuelHandler) {
        this.fuelHandler = fuelHandler;

        List<FuelHandler.Fuel> fuelList = fuelHandler.GetFuelList();
        Vector2 itemAnchoredPosition = new Vector2(0, 0);
        for (int i = 0; i < fuelList.Count; i++) {
            FuelHandler.Fuel fuel = fuelList[i];
            CreateBarImage(itemAnchoredPosition).SetBarFragments(fuel.GetFragmentAmount());
            itemAnchoredPosition += new Vector2(15, 0);
        }

        fuelHandler.OnAddFuel += FuelHandler_OnAddFuel;
    }

    private void FuelHandler_OnAddFuel(object sender, System.EventArgs e) {
        //fuel added
        List<FuelHandler.Fuel> fuelList = fuelHandler.GetFuelList();
        for(int i = 0; i < barImageList.Count; i++) {
            BarImage barImage = barImageList[i];
            FuelHandler.Fuel fuel = fuelHandler.GetFuelList()[i];
            barImage.SetBarFragments(fuel.GetFragmentAmount());
        }
    }

    private BarImage CreateBarImage(Vector2 anchoredPosition) {
        //create game object
        GameObject barGameObject = new GameObject("Bar", typeof(Image));

        //set as child of this transform
        barGameObject.transform.SetParent(transform);
        barGameObject.transform.localPosition = Vector3.zero;
       
        //locate and size heart
        barGameObject.GetComponent<RectTransform>().anchoredPosition = anchoredPosition;
        barGameObject.GetComponent<RectTransform>().sizeDelta = new Vector2 (10, 10);
      
        //set heart sprite
        Image barImageUI = barGameObject.GetComponent<Image>();
        barImageUI.sprite = bar0Sprite;

        BarImage barImage = new BarImage(this, barImageUI);
        barImageList.Add(barImage);

        return barImage;
    }

    public class BarImage {

        private Image barImage;
        private CargoBarUI cargoBarUI;

        public BarImage(CargoBarUI cargoBarUI, Image barImage) {
            this.cargoBarUI = cargoBarUI;
            this.barImage = barImage;
        }

        public void SetBarFragments(int fragments) {
            switch (fragments) {
                case 0: barImage.sprite = cargoBarUI.bar0Sprite; break;
                case 1: barImage.sprite = cargoBarUI.bar1Sprite; break;
                case 2: barImage.sprite = cargoBarUI.bar2Sprite; break;
                case 3: barImage.sprite = cargoBarUI.bar3Sprite; break;
                case 4: barImage.sprite = cargoBarUI.bar4Sprite; break;
            }
        }
    }
}
