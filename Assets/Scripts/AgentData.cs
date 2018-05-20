using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AgentData {

    public int ageRange;
    public string startCounty;
    public Transform endDestination;

    public AgentData(int ageRange, string startCounty, Transform endDestination)
    {
        this.ageRange = ageRange;
        this.startCounty = startCounty;
        this.endDestination = endDestination;
    }
}
