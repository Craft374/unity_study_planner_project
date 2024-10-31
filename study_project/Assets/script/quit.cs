using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.IO;
using UnityEngine.Events;
using UnityEngine.Android;
using TMPro;

public class quit : MonoBehaviour
{
    public Button yes;
    public Button no;
    public GameObject obj;
    void Start()
    {
        GameObject yesbutton_obj = GameObject.Find("yes_q");
        yes = yesbutton_obj.GetComponent<Button>();

        GameObject nobutton_obj = GameObject.Find("no_q");
        no = nobutton_obj.GetComponent<Button>();
        
        yes.onClick.AddListener(yes_click);
        no.onClick.AddListener(no_click);

        obj = GameObject.Find("exit?");
        obj.gameObject.SetActive(false);

    }
    public void yes_click()
    {
        Application.Quit();
    }
    public void no_click()
    {
        obj.gameObject.SetActive(false);
    }
    void FixedUpdate()
    {
        if(Input.GetKey(KeyCode.Escape))
        {
        obj.gameObject.SetActive(true);
        }
    }
}
