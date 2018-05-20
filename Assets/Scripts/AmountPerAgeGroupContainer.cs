using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AmountPerAgeGroupContainer : MonoBehaviour {

    public Dictionary<int, AmountPerAgeGroup> amountsPerAgeGroup = new Dictionary<int, AmountPerAgeGroup>();

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
            
            if (data[0] != "Year" && line != string.Empty)
            {
                AmountPerAgeGroup aData = new AmountPerAgeGroup(
                int.Parse(data[headers["Year"]]),
                float.Parse(data[headers["age_u19"]]),
                float.Parse(data[headers["age_20-24"]]),
                float.Parse(data[headers["age_25-29"]]),
                float.Parse(data[headers["age_30-34"]]),
                float.Parse(data[headers["age_35-39"]]),
                float.Parse(data[headers["age_40u"]])
            );

                amountsPerAgeGroup.Add(int.Parse(data[headers["Year"]]), aData);
            }
        }
    }

    public AmountPerAgeGroup getAmountPerAgeGroupByYear(int year)
    {
        return amountsPerAgeGroup[year];
    }
}
