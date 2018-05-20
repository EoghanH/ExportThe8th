using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Logic : MonoBehaviour {

    int year = 1991;
    int month = 1;
    public int ticksPerYear = 3000;
    public int ticksPassed = 0;
    public float tickTime = 0.05f;

    public GameObject countiesContainer;

	void Start () {
        Random.InitState(8);
        this.GetComponent<DataLoader>().init();
        Debug.Log("Calling year setup for year: " + year);
        countiesContainer.GetComponent<SpawningParent>().setupYear(year);

        InvokeRepeating("tickUpdate", 0f, tickTime);
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void tickUpdate()
    {
        if (ticksPassed >= ticksPerYear)
        {
            if (year < 2016)
            {
                year++;
                countiesContainer.GetComponent<SpawningParent>().setupYear(year);
                this.GetComponent<StatCounter>().setupYear(year);
                ticksPassed = 0;
            } else
            {
                CancelInvoke();
            }
        }
        countiesContainer.GetComponent<SpawningParent>().doTick(ticksPassed);
        this.GetComponent<StatCounter>().doTick(ticksPassed, ticksPerYear);
        ticksPassed++;
    }
}
