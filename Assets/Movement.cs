using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Movement : MonoBehaviour
{
    private Vector3 target;

    // Start is called before the first frame update
    private NavMeshAgent agent;

    [SerializeField]
    private GameObject searchRadius;

    private Traits traits;

    private status stats;
    private InSight sightings;

    void Start()
    {
        traits = GetComponent<Traits>();
        agent = GetComponent<NavMeshAgent>();
        stats = GetComponent<status>();
        sightings = GetComponentInChildren<InSight>();
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 pos = GetComponent<Transform>().position;
        //Debug.Log(GetComponent<Transform>().position);
        if (agent.destination == pos)
        {
            target = sightings.GetTarget();

            new WaitForSeconds(1);
            //Debug.Log("Finding new location");
            //agent.transform.localPosition += new Vector3(0.0f, 2.0f, 0.0f);
            
            
            agent.SetDestination(target);
        }
    }

    
}
