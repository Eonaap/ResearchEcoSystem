using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Timer : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField]
    private Text timerText;

    [SerializeField]
    private Text timeSpeedText;

    private float time;
    void Start()
    {
        if (timerText == null)
        {
            timerText = GetComponentInChildren<Text>();
        }
        timerText.text = "0";

        if (timeSpeedText == null)
        {
            timeSpeedText = GameObject.FindGameObjectWithTag("TimeSpeed").GetComponentInChildren<Text>();
        }
        timeSpeedText.text = "1";
    }

    // Update is called once per frame
    void Update()
    {
        time += Time.deltaTime;

        timerText.text = TimeSpan.FromSeconds(time).ToString();

        if (Input.GetKeyDown(KeyCode.P))
        {
            Time.timeScale++;
            timeSpeedText.text = Time.timeScale.ToString();
        }

        if (Input.GetKeyDown(KeyCode.O))
        {
            Time.timeScale--;
            timeSpeedText.text = Time.timeScale.ToString();
        }
    }
}
