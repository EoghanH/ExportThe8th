using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LerpTravelPoint : MonoBehaviour {

    public GameObject nextPoint;
    public bool isEndPoint = false;

    void OnTriggerEnter(Collider c)
    {
        if (c.gameObject.name == "Agent")
        {
            if (isEndPoint)
            {
                Destroy(c.gameObject);
            } else
            {
                c.GetComponent<PathingAgent>().getNewLerpPoint(nextPoint.transform);
            }
        }
    }
}
