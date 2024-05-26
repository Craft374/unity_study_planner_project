using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.IO;
using UnityEngine.Events;
using UnityEngine.Android;
using TMPro;

public class save : MonoBehaviour
{    
    public Button LB;
    public Button RB;
    public string fullPath;
    public main mainScript;
    public onoff onoffScript;

    void Start()
    {
        mainScript = GetComponent<main>(); 
        onoffScript = GetComponent<onoff>();
        // fullPath = Application.persistentDataPath;
        Debug.Log(onoffScript.memo.ToString());
        Debug.Log(onoffScript.p_name.ToString());


        fullPath = Application.dataPath + "/StreamingAssets";
        GameObject leftbutton_obj = GameObject.Find("LB");
        LB = leftbutton_obj.GetComponent<Button>();
        GameObject rightbutton_obj = GameObject.Find("RB");
        RB = rightbutton_obj.GetComponent<Button>();

        LB.onClick.AddListener(LB_click);
        RB.onClick.AddListener(RB_click);

        string path = fullPath + "/" + DateTime.Today.ToString("yyyy-MM-dd") + ".txt";
        
        try
        {
            // 파일이 이미 존재하는지 확인
            if (!File.Exists(path))
            {
                // 파일이 없으면 새로운 파일을 생성하고 내용을 작성
                using (StreamWriter writer = File.CreateText(path))
                {
                    writer.WriteLine("Hello, World!");
                    writer.WriteLine("This is a test file.");
                }

                Debug.Log(path +" 파일이 생성되었습니다.");
            }
            else
            {
                Debug.Log(path +" 파일이 이미 존재합니다.");
            }
        }

        catch (System.Exception ex)
        {
            Debug.LogError("파일을 생성하는 도중 오류가 발생했습니다: " + ex.Message);
        }
    }


    // void Update()
    // {
        // string path = fullPath + mainScript.today.ToString("yyyy-MM-dd") + ".txt";
        // main mainScript = GetComponent<main>();
    //     // Debug.Log(mainScript.today.ToString("yyyy-MM-dd"));
    // }
    public void LB_click()
    {
        Debug.Log("왼 됨");
        string path = fullPath + "/" + mainScript.today.ToString("yyyy-MM-dd") + ".txt";

        try
        {
            // 파일이 이미 존재하는지 확인
            if (!File.Exists(path))
            {
                // 파일이 없으면 새로운 파일을 생성하고 내용을 작성
                using (StreamWriter writer = File.CreateText(path))
                {
                    writer.WriteLine("Hello, World!");
                    writer.WriteLine("This is a test file.");
                }

                Debug.Log(path +" 파일이 생성되었습니다.");
            }
            else
            {
                Debug.Log(path +" 파일이 이미 존재합니다.");
            }
        }

        catch (System.Exception ex)
        {
            Debug.LogError("파일을 생성하는 도중 오류가 발생했습니다: " + ex.Message);
        }
    }
    public void RB_click()
    {
        Debug.Log("오른 됨");
        string path = fullPath + "/" + mainScript.today.ToString("yyyy-MM-dd") + ".txt";

        try
        {
            // 파일이 이미 존재하는지 확인
            if (!File.Exists(path))
            {
                // 파일이 없으면 새로운 파일을 생성하고 내용을 작성
                using (StreamWriter writer = File.CreateText(path))
                {
                    writer.WriteLine("Hello, World!");
                    writer.WriteLine("This is a test file.");
                }

                Debug.Log(path +" 파일이 생성되었습니다.");
            }
            else
            {
                Debug.Log(path +" 파일이 이미 존재합니다.");
            }
        }

        catch (System.Exception ex)
        {
            Debug.LogError("파일을 생성하는 도중 오류가 발생했습니다: " + ex.Message);
        }
    }
}
