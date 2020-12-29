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
        if (agent.destination == transform.position)
        {
            target = sightings.GetTarget();
            
            agent.SetDestination(target);
        }
    }

    
}
