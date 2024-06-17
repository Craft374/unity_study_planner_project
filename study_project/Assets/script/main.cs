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
    public int todaynumber;
    public int dayvalue;

    public TMP_Text todayTMP;
    public TMP_Text yoilTMP;
    public Button LB;
    public Button RB;
    public DateTime today;
    public GameObject content;
    void Start()
    {
        GameObject todaytext_obj = GameObject.Find("todaytext");
        todayTMP = todaytext_obj.GetComponent<TMP_Text>();
        GameObject yoil_obj = GameObject.Find("yoil_t");
        yoilTMP = yoil_obj.GetComponent<TMP_Text>();
        GameObject leftbutton_obj = GameObject.Find("LB");
        LB = leftbutton_obj.GetComponent<Button>();
        GameObject rightbutton_obj = GameObject.Find("RB");
        RB = rightbutton_obj.GetComponent<Button>();

        content = GameObject.Find("Content");

        today = DateTime.Today;
        date = today.ToString("yyyy-MM-dd");
        day = today.ToString("dddd");
        // Debug.Log(date);
        // Debug.Log(day);
        todayTMP.text = date;
        yoilTMP.text = day;
        dayvalue = 0;
        
        todaynumber = (int)today.DayOfWeek;
        // Debug.Log("요일 숫자: " + todaynumber);
        LB.onClick.AddListener(LB_click);
        RB.onClick.AddListener(RB_click);
    }

    public void LB_click()
    {
        //Debug.Log("LB");
        dayvalue -= 1;
        todaynumber -= 1; //어제를 숫자로 표시
        if (todaynumber == -1)
        {
            todaynumber = 6;
        }
        //Debug.Log(today.DayOfWeek); 영어로 요일뜸
        string dayName = System.Globalization.CultureInfo.CurrentCulture.DateTimeFormat.GetDayName((DayOfWeek)todaynumber);
        // Debug.Log(dayName);
        yoilTMP.text = dayName;
        today = DateTime.Today.AddDays(dayvalue);
        // Debug.Log(today.ToString("yyyy-MM-dd"));
        todayTMP.text = today.ToString("yyyy-MM-dd");
        Delete();
    }
    public void RB_click()
    {
        //Debug.Log("RB");
        dayvalue += 1;    
        todaynumber += 1; //내일 숫자로 표시
        if (todaynumber == 7)
        {
            todaynumber = 0;
        }
        string dayName = System.Globalization.CultureInfo.CurrentCulture.DateTimeFormat.GetDayName((DayOfWeek)todaynumber);
        // Debug.Log(dayName);
        yoilTMP.text = dayName;
        today = DateTime.Today.AddDays(dayvalue);
        // Debug.Log(today.ToString("yyyy-MM-dd"));
        todayTMP.text = today.ToString("yyyy-MM-dd");
        Delete();
    }

    public void Delete()
    {
        foreach (Transform child in content.transform)
        {
            if (child.gameObject.name != "addbtn")
            {
                Destroy(child.gameObject);
            }
        }
    }
}
