using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Pathfinding;

public class PathingAgent : MonoBehaviour {

    /**
     * Age Ranges
     * 0 = U19
     * 1 = 20-24
     * 2 = 25-29
     * 3 = 30-34
     * 4 = 35-39
     * 5 = 40U
     */
    public int ageRange = 0;
    public Material[] ageRangeMats;
    public Material[] ageRangeTrailRenderMats;
    public Transform destination;
    public GameObject viewObject;

    public bool hasLerpPoint = false;
    public Transform startPosition;
    public Transform lerpPoint;
    public float lerpPosition = 0f;
    public float lerpSpeed = 0.1f;

    private void FixedUpdate()
    {
        if (hasLerpPoint && lerpPoint != null)
        {
            transform.position = Vector3.MoveTowards(transform.position, lerpPoint.position, lerpSpeed * Time.deltaTime);
        }
    }

    public void init(int ageRange, Transform destination, StatCounter statCounter)
    {
        this.ageRange = ageRange;
        this.viewObject.GetComponent<Renderer>().material = ageRangeMats[ageRange];
        this.destination = destination;
        this.GetComponent<AIDestinationSetter>().target = destination;

        switch (ageRange)
        {
            case 0: { break; }
            case 1: { viewObject.transform.position += new Vector3(0, 0.06f, 0); break; }
            case 2: { viewObject.transform.position += new Vector3(0, 0.12f, 0); break; }
            case 3: { viewObject.transform.position += new Vector3(0, 0.18f, 0); break; }
            case 4: { viewObject.transform.position += new Vector3(0, -0.06f, 0); break; }
            case 5: { viewObject.transform.position += new Vector3(0, -0.12f, 0); break; }
        }

        statCounter.addAgent(ageRange);
    }

    public void getNewLerpPoint(Transform lerpPoint)
    {
        if (this.GetComponent<AIPath>())
        {
            Destroy(this.GetComponent<AIPath>());
        }

        if (this.hasLerpPoint == false)
        {
            this.hasLerpPoint = true;
        }
        this.startPosition = this.transform;
        this.lerpPoint = lerpPoint;
    }

    public void getNewLerpPoint(Transform lerpPoint, float speed)
    {
        this.lerpSpeed = speed;
        getNewLerpPoint(lerpPoint);
    }
}
