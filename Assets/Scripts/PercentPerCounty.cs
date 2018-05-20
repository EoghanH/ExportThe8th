using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PercentPerCounty : MonoBehaviour {

    public Dictionary<string, float> percentPerCounty =  new Dictionary<string, float>();

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

            if (data[0] != "County" && line != string.Empty)
            {
                percentPerCounty.Add(data[headers["County"]], float.Parse(data[headers["Percent"]]));
            }
        }
    }

    public float getPercentForCounty(string county)
    {
        return percentPerCounty[county] / 100f;
    }

    public List<string> getAllCounties()
    {
        List<string> counties = new List<string>();
        foreach (KeyValuePair<string, float> county in percentPerCounty)
        {
            counties.Add(county.Key);
        }

        return counties;
    }

}
