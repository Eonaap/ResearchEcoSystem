using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class InSight : MonoBehaviour
{

    private Collider targetPlant = new Collider();
    private Collider targetWater;
    private Collider targetBunny;
    private status stats;
    private bool isThirsty, isHungry, isHorny;
    private NavMeshAgent agent;

    [SerializeField]
    private GameObject plantPrefab;

    // Start is called before the first frame update
    void Start()
    {
        stats = GetComponentInParent<status>();
        agent = GetComponentInParent<NavMeshAgent>();
    }

    // Update is called once per frame
    void Update()
    {
        if (stats == null)
        {
            stats = GetComponentInParent<status>();
        }

        Collider[] hitCollider = Physics.OverlapSphere(gameObject.transform.position, 4.0f);

        foreach (Collider foundObject in hitCollider)
        {
            if (foundObject.tag == "Plant")
            {
                if (targetPlant == null)
                {
                    targetPlant = foundObject;
                   //Debug.Log("Plant changed");
                }

                if (Vector3.Distance(targetPlant.transform.position, this.transform.position) > Vector3.Distance(foundObject.transform.position, this.transform.position))
                {
                    targetPlant = foundObject;
                    //Debug.Log("Plant changed");
                }
            }

            if (foundObject.tag == "Water")
            {
                if (targetWater == null)
                {
                    targetWater = foundObject;
                    //Debug.Log("Water changed");
                }

                if (Vector3.Distance(targetWater.transform.position, this.transform.position) > Vector3.Distance(foundObject.transform.position, this.transform.position))
                {
                    targetPlant = foundObject;
                    //Debug.Log("Water changed");
                }
            }
        }
        NavMeshHit hit;
        if (targetPlant != null && !NavMesh.SamplePosition(targetPlant.transform.position, out hit, 1.0f, NavMesh.AllAreas))
        {
            Debug.Log("Plant too far away");
            DestroyObject(targetPlant.gameObject);
            targetPlant = null;
        }
    }

    public Vector3 GetTarget()
    {
        string targetType = stats.GetTargetType();
        if (targetType == "Wander")
        {
            Vector3 randomDirection = UnityEngine.Random.insideUnitSphere * 5;
            randomDirection += transform.position;
            NavMeshHit hit;
            NavMesh.SamplePosition(randomDirection, out hit, 25, 1);
            return hit.position;
        }

        if (targetWater != null && Vector3.Distance(targetWater.transform.position, this.transform.position) < 3.0f && targetType == "Thirsty")
        {
            stats.Drink();
            targetWater = null;
            return transform.position;
        }

        if (targetPlant != null && Vector3.Distance(targetPlant.transform.position, this.transform.position) < 4.0f)
        {
            stats.Eat();
            DestroyObject(targetPlant.gameObject);

            targetPlant = null;
            Vector3 randomDirection = UnityEngine.Random.insideUnitSphere * 5;
            randomDirection += transform.position;
            NavMeshHit hit;
            NavMesh.SamplePosition(randomDirection, out hit, 25, 1);

            Instantiate(plantPrefab, hit.position, Quaternion.identity);
            return transform.position;
        }

        

        if (targetType == "Hungry")
        {
            if (targetPlant != null)
            {
                return targetPlant.transform.position;
            }
            else if (targetWater != null && stats.IsThirsty())
            {
                return targetWater.transform.position;
            }
            else
            {
                Vector3 randomDirection = UnityEngine.Random.insideUnitSphere * 5;
                randomDirection += transform.position;
                NavMeshHit hit;
                NavMesh.SamplePosition(randomDirection, out hit, 25, 1);
                return hit.position;
            }

        }
        else if (targetType == "Thirsty")
        {
            if (targetWater != null)
            {
                return targetWater.transform.position;
            }
            else if (targetPlant != null)
            {
                return targetPlant.transform.position;
            }
            else
            {
                Vector3 randomDirection = UnityEngine.Random.insideUnitSphere * 5;
                randomDirection += transform.position;
                NavMeshHit hit;
                NavMesh.SamplePosition(randomDirection, out hit, 25, 1);
                return hit.position;
            }
        }
        else
        {
            Vector3 randomDirection = UnityEngine.Random.insideUnitSphere * 5;
            randomDirection += transform.position;
            NavMeshHit hit;
            NavMesh.SamplePosition(randomDirection, out hit, 25, 1);
            return hit.position;
        }
    }
}
