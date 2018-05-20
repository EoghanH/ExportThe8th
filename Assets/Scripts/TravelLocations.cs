using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TravelLocations : MonoBehaviour {

    public Dictionary<string, float> travelLocations = new Dictionary<string, float>();

    public void init(TextAsset csv)
    {
        string[] lines = csv.text.Split('\n');
        string[] headersData = lines[0].Split(',');
        Dictionary<string, int> headers = new Dictionary<string, int>();
        for (int headerIndex = 0; headerIndex < headersData.Length; headerIndex++)
        {
            headers.Add(headersData[headerIndex], headerIndex);
        }

        foreach (string line in lines)
        {
            string[] data = line.Split(',');

            if (data[0] != "Location" && line != string.Empty)
            {
                travelLocations.Add(data[headers["Location"]], float.Parse(data[headers["Percent"]]));
            }
        }
    }

    public float getTravelPercent(string location)
    {
        return travelLocations[location];
    }

    public Dictionary<string, float> getAllDestinationChances()
    {
        return travelLocations;
    }
}
