using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class CountySpawner : MonoBehaviour {

    public AgentData[] agentsToSpawn;
    public GameObject pathfindingAgentObject;
    public GameObject agentContainer;
    public StatCounter statCounter;

    private void Start()
    {
        this.agentContainer = GameObject.Find("Pathfinders");
        this.statCounter = GameObject.Find("Logic").GetComponent<StatCounter>();
    }

    public void doTick(int tickNumber)
    {
        if (agentsToSpawn.ElementAtOrDefault(tickNumber) != null)
        {
            AgentData data = agentsToSpawn[tickNumber];
            GameObject newAgent = Instantiate(pathfindingAgentObject, this.transform.position, Quaternion.identity) as GameObject;
            newAgent.GetComponent<PathingAgent>().init(data.ageRange, data.endDestination, this.statCounter);
            newAgent.name = "Agent";
            newAgent.transform.parent = agentContainer.transform;
        }
    }

    public void loadYearList(List<AgentData> agentsToSpawn, int ticksPerYear)
    {
        AgentData[] newAgentsList = new AgentData[ticksPerYear];
        agentsToSpawn = agentsToSpawn.OrderBy(x => Random.value).ToList();
        int agentsReceived = agentsToSpawn.Count;
        int pointer = 0;
        foreach (AgentData agent in agentsToSpawn)
        {
            newAgentsList[pointer] = agent;
            pointer += ticksPerYear / agentsReceived;
        }

        this.agentsToSpawn = newAgentsList;
    }

    private void outputAllAgents()
    {
        for (int i = 0; i < this.agentsToSpawn.Length; i++)
        {
            if (agentsToSpawn.ElementAtOrDefault(i) != null)
            {
                Debug.Log("For County " + this.gameObject.name + " : Agent to spawn at position " + i);
            }
        }
    }

}
