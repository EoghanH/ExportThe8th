using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Pathfinding;

public class EndPoint : MonoBehaviour {

    public bool multiplePoints = false;
    public GameObject startingLerpObject;
    public GameObject[] multipleStartingLerpObjects;
    public float speedOfTravel = 6f;

    void OnTriggerEnter(Collider c)
    {
        if (c.gameObject.name == "Agent")
        {
            if (c.gameObject.GetComponent<AIDestinationSetter>().target.gameObject.name == this.gameObject.name && (startingLerpObject != null || multipleStartingLerpObjects.Length > 0))
            {
                if (multiplePoints)
                {
                    GameObject chosenLerpObject = multipleStartingLerpObjects[Random.Range(0, multipleStartingLerpObjects.Length)];
                    c.gameObject.layer = chosenLerpObject.layer;
                    c.gameObject.GetComponent<PathingAgent>().getNewLerpPoint(chosenLerpObject.transform, speedOfTravel);
                } else
                {
                    c.gameObject.layer = this.startingLerpObject.layer;
                    c.gameObject.GetComponent<PathingAgent>().getNewLerpPoint(startingLerpObject.transform, speedOfTravel);
                }
            }
        }
    }
}
