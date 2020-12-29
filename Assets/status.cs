using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class status : MonoBehaviour
{
    private float currentHealth,currentThirst, currentHunger, matingUrge;

    private GameObject mainCam;

    [SerializeField]
    private Canvas canvas;

    [SerializeField]
    private Image hungerBar, thirstBar, healthBar;

    [SerializeField]
    private float maxHealth, maxThirst, maxHunger;
    // Start is called before the first frame update

    [SerializeField]
    private float drinkCooldown;
    private float eatCooldown;

    private float currentDrinkCooldown;
    private float currentEatCooldown;
    void Start()
    {
        currentHealth = maxHealth;
        currentThirst = maxThirst;
        currentHunger = maxHunger;

        mainCam = GameObject.FindGameObjectWithTag("MainCamera");
    }

    // Update is called once per frame
    void Update()
    {
        currentThirst -= Time.deltaTime;
        currentHunger -= Time.deltaTime;

        if (currentHealth < maxHealth)
            currentHealth += Time.deltaTime * 0.1f;

        hungerBar.fillAmount = currentHunger / maxHunger;
        thirstBar.fillAmount = currentThirst / maxThirst;
        healthBar.fillAmount = currentHealth / maxHealth;

        canvas.transform.LookAt(mainCam.transform.position);
        canvas.transform.rotation = Quaternion.LookRotation(canvas.transform.position - mainCam.transform.position);

        if (currentThirst < 0.0f)
            currentThirst = 0.0f;

        if (currentHunger < 0.0f)
            currentHunger = 0.0f;

        if (currentDrinkCooldown > 0.0f)
        {
            currentDrinkCooldown -= Time.deltaTime;
        }
        if (currentEatCooldown > 0.0f)
        {
            currentEatCooldown -= Time.deltaTime;
        }

        if (currentHunger == 0.0f)
        {
            //Debug.Log("You're dying");
            if (currentThirst == 0.0f)
            {
                currentHealth -= 1.5f * Time.deltaTime;
            }
            else
            {
                currentHealth -= 0.75f * Time.deltaTime;
            }
        }

        if (currentHealth <= 0.0f)
        {
            Destroy(gameObject);
        }
    }

    public void Eat()
    {
        //Debug.Log("Eating");
        currentHunger += 25.0f;
        if (currentHunger > maxHunger)
        {
            currentHunger = maxHunger;
            currentEatCooldown = eatCooldown;
        }
            
    }

    public void Drink()
    {
        //Debug.Log("Drinking");
        currentThirst += 25.0f;
        if (currentThirst > maxThirst)
        {
            currentThirst = maxThirst;
            currentDrinkCooldown = drinkCooldown;
        }
            
    }

    public bool IsThirsty()
    {
        if (currentThirst / maxThirst < 0.65f)
            return true;

        return false;
    }

    public string GetTargetType()
    {
        if (drinkCooldown > 0.0f)
            return "Wander";

        if (eatCooldown > 0.0f)
        {
            return "Wander";
        }

        if (currentHunger / maxHunger < 0.4f && currentThirst > currentHunger )
        {
            return "Hungry";
        }
        else if (currentThirst / maxThirst < 0.4f && currentHunger > currentThirst)
        {
            return "Thirsty";
        }

        if (currentHunger/maxHunger > 0.75f)
        {
            if (currentThirst/maxThirst > 0.75f)
            {
                return "Wander";
            }
            return "Thirsty";
        }

        if (currentDrinkCooldown > 0.0f)
        {
            return "Hungry";
        }

        if (currentHunger < currentThirst)
        {
            return "Hungry";
        }
        else
        {
            return "Thirsty";
        }
    }
}
