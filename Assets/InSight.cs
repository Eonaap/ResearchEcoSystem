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
        Collider[] hitCollider = Physics.OverlapSphere(gameObject.transform.position, 3.0f);

        foreach (Collider foundObject in hitCollider)
        {
            if (foundObject.tag == "Plant")
            {
                if (targetPlant == null)
                {
                    targetPlant = foundObject;
                    Debug.Log("Plant changed");
                }

                if (Vector3.Distance(targetPlant.transform.position, this.transform.position) > Vector3.Distance(foundObject.transform.position, this.transform.position))
                {
                    targetPlant = foundObject;
                    Debug.Log("Plant changed");
                }
            }

            if (foundObject.tag == "Water")
            {
                if (targetWater == null)
                {
                    targetWater = foundObject;
                    Debug.Log("Water changed");
                }

                if (Vector3.Distance(targetWater.transform.position, this.transform.position) > Vector3.Distance(foundObject.transform.position, this.transform.position))
                {
                    targetPlant = foundObject;
                    Debug.Log("Water changed");
                }
            }
        }
    }

    public Vector3 GetTarget()
    {
        if (targetPlant != null && Vector3.Distance(targetPlant.transform.position, this.transform.position) < 1.0f)
        {
            stats.Eat();
            DestroyObject(targetPlant.gameObject);

            Vector3 randomDirection = UnityEngine.Random.insideUnitSphere * 5;
            randomDirection += transform.position;
            NavMeshHit hit;
            NavMesh.SamplePosition(randomDirection, out hit, 25, 1);

            Instantiate(plantPrefab, hit.position, Quaternion.identity);
            return transform.position;
        }

        if (targetWater != null && Vector3.Distance(targetWater.transform.position, this.transform.position) < 15.0f && stats.GetTargetType() == "Thirsty")
        {
            stats.Drink();
            targetWater = null;
            //DestroyObject(targetWater.gameObject);
            return transform.position;
        }

        if (stats.GetTargetType() == "Hungry")
        {
            if (targetPlant != null)
            {
                return targetPlant.transform.position;
            }
            else if (targetWater != null)
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
        else if (stats.GetTargetType() == "Thirsty")
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
