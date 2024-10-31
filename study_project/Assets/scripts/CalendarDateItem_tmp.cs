using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.IO;
using UnityEngine.Events;
using UnityEngine.Android;
using TMPro;

public class CalendarDateItem_tmp : MonoBehaviour {

    public void OnDateItemClick()
    {
        CalendarController_tmp._calendarInstance.OnDateItemClick(gameObject.GetComponentInChildren<TMP_Text>().text);
    }
}
