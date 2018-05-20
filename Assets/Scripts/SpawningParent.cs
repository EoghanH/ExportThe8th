using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawningParent : MonoBehaviour {

    public Dictionary<string, GameObject> spawnCounties = new Dictionary<string, GameObject>();
    public GameObject pathfindingAgentObject;

    public GameObject rosslarePort;
    public GameObject dublinPort;
    public GameObject dublinAirport;
    public GameObject belfastAirport;
    public GameObject corkAirport;

    public GameObject agentContainer;
    public GameObject dataLoader;
    public GameObject logic;

    //lol this could've been cleaner. Fuck it, I'm tired and it works.
    public void setupYear(int year)
    {
        if (spawnCounties.Count == 0)
        {
            foreach (Transform child in this.transform)
            {
                spawnCounties.Add(child.name, child.gameObject);
            }
        }

        AmountPerAgeGroup amount = dataLoader.GetComponent<DataLoader>().amountPerAgeGroupContainer.GetComponent<AmountPerAgeGroupContainer>().getAmountPerAgeGroupByYear(year);
        PercentPerCounty percentPerCounty = dataLoader.GetComponent<DataLoader>().percentPerCounty.GetComponent<PercentPerCounty>();

        Dictionary<string, Dictionary<string, int>> amountsPerCounty = new Dictionary<string, Dictionary<string, int>>();
        List<string> allCounties = percentPerCounty.getAllCounties();

        foreach (string county in allCounties)
        {
            Dictionary<string, int> amountsPerAgeGroup = new Dictionary<string, int>();
            amountsPerAgeGroup.Add("amount_u19", Mathf.RoundToInt(percentPerCounty.getPercentForCounty(county) * amount.amount_u19));
            amountsPerAgeGroup.Add("amount_20_24", Mathf.RoundToInt(percentPerCounty.getPercentForCounty(county) * amount.amount_20_24));
            amountsPerAgeGroup.Add("amount_25_29", Mathf.RoundToInt(percentPerCounty.getPercentForCounty(county) * amount.amount_25_29));
            amountsPerAgeGroup.Add("amount_30_34", Mathf.RoundToInt(percentPerCounty.getPercentForCounty(county) * amount.amount_30_34));
            amountsPerAgeGroup.Add("amount_35_39", Mathf.RoundToInt(percentPerCounty.getPercentForCounty(county) * amount.amount_35_39));
            amountsPerAgeGroup.Add("amount_40u", Mathf.RoundToInt(percentPerCounty.getPercentForCounty(county) * amount.amount_40u));
            amountsPerCounty.Add(county, amountsPerAgeGroup);
        }

        foreach (KeyValuePair<string, GameObject> county in spawnCounties)
        {
            List<AgentData> agentsData = new List<AgentData>();
            foreach (KeyValuePair<string, int> rawAgent in amountsPerCounty[county.Key])
            {
                for (int i = 0; i < rawAgent.Value; i++)
                {
                    AgentData newAgent = new AgentData(convertAgeRange(rawAgent.Key), county.Key, selectLeavingDestination(county.Key));
                    agentsData.Add(newAgent);
                }
            }
            Debug.Log("Added " + agentsData.Count + " Agents");

            spawnCounties[county.Key].GetComponent<CountySpawner>().loadYearList(agentsData, logic.GetComponent<Logic>().ticksPerYear);
        }
    }
	
	public void doTick(int tickNumber)
    {
        foreach (KeyValuePair<string, GameObject> c in spawnCounties)
        {
            c.Value.GetComponent<CountySpawner>().doTick(tickNumber);
        }
    }

    //why did I not just set up an enum
    public int convertAgeRange(string ageRange)
    {
        switch (ageRange)
        {
            case "amount_u19": return 0;
            case "amount_20_24": return 1;
            case "amount_25_29": return 2;
            case "amount_30_34": return 3;
            case "amount_35_39": return 4;
            case "amount_40u": return 5;
            case "default": return 6;
        }
        return 0;
    }

    //this is probably the worst offender in the entire codebase
    public Transform selectLeavingDestination(string county)
    {
        Transform destination = null;
        float chance = Random.Range(0, 100f);

        if (county.ToLower() == "dublin")
        {
            if (chance < 80f)
            {
                destination = dublinAirport.transform;
            } else
            {
                destination = dublinPort.transform;
            }
        }

        if (county.ToLower() == "cork")
        {
            if (chance < 50f)
            {
                destination = corkAirport.transform;
            }
        }

        if (county.ToLower() == "donegal")
        {
            if (chance < 60f)
            {
                destination = belfastAirport.transform;
            } else
            {
                destination = dublinAirport.transform;
            }
        }

        if (county.ToLower() == "louth")
        {
            if (chance < 20f)
            {
                destination = belfastAirport.transform;
            }
            else
            {
                destination = dublinAirport.transform;
            }
        }

        if (county.ToLower() == "monaghan")
        {
            if (chance < 10f)
            {
                destination = belfastAirport.transform;
            }
            else
            {
                destination = dublinAirport.transform;
            }
        }

        if (destination == null)
        {
            if (chance < 82f)
            {
                destination = dublinAirport.transform;
            }
            else if (chance < 90f)
            {
                destination = corkAirport.transform;
            }
            else if (chance < 96f)
            {
                destination = dublinPort.transform;
            }
            else
            {
                destination = rosslarePort.transform;
            }
        }

        return destination;
    }
}
