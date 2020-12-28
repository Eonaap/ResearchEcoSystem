using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Traits : MonoBehaviour
{
    // Start is called before the first frame update
    private float speedGene, healthGene, currentHealth, thirstGene, currentThirst, hungerGene, currentHunger;
    void Start()
    {
        speedGene = Random.Range(0.5f, 3.0f);
        healthGene = Random.Range(0.5f, 3.0f);
        thirstGene = Random.Range(0.5f, 3.0f);
        hungerGene = Random.Range(0.5f, 3.0f);
    }

    float GetSpeed()
    {
        return speedGene;
    }

    float GetHealth()
    {
        return healthGene;
    }

    float GetThirst()
    {
        return thirstGene;
    }

    float GetHunger()
    {
        return hungerGene;
    }
}
