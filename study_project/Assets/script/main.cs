using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.IO;
using UnityEngine.Events;
using UnityEngine.Android;
using TMPro;

public class main : MonoBehaviour
{
    public string date;
    public string day;
    public TMP_Text todayTMP;
    public TMP_Text yoilTMP;

    void Start()
    {
        GameObject todaytext = GameObject.Find("todaytext");
        todayTMP = todaytext.GetComponent<TMP_Text>();

        GameObject yoil = GameObject.Find("yoil_t");
        yoilTMP = yoil.GetComponent<TMP_Text>();

        DateTime today = DateTime.Today;
        date = today.ToString("yyyy-MM-dd");
        day = today.ToString("dddd");
        Debug.Log(date);
        Debug.Log(day);
        todayTMP.text = date;
        yoilTMP.text = day;

        int dayOfWeekNumber = (int)today.DayOfWeek;
        Debug.Log("요일 숫자: " + dayOfWeekNumber);
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        
    }
}
