using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DataLoader : MonoBehaviour {

    public TextAsset inputAmountPerAgeGroup;
    public TextAsset inputPercentPerCounty;
    public TextAsset inputTravelLocations;

    public GameObject amountPerAgeGroupContainer;
    public GameObject percentPerCounty;
    public GameObject travelLocations;

    public GameObject countyHandler;

	public void init()
    {
        amountPerAgeGroupContainer.GetComponent<AmountPerAgeGroupContainer>().init(inputAmountPerAgeGroup);
        percentPerCounty.GetComponent<PercentPerCounty>().init(inputPercentPerCounty);
        travelLocations.GetComponent<TravelLocations>().init(inputTravelLocations);
    }
}
