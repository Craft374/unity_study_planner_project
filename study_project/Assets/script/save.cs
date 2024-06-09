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
    public string path;
    public main mainScript;
    public string p_name;
    public string memo;
    private GameObject nameObj;
    private GameObject memoObj;
    public int Line =0;
    void Start()
    {   
        Line = 0;

        nameObj = GameObject.Find("A");
        memoObj = GameObject.Find("B");
        
        p_name = nameObj.name.ToString();
        memo = memoObj.name.ToString();

        // Debug.Log($"{p_name} {memo}");
        mainScript = GetComponent<main>(); 
        
        // fullPath = Application.persistentDataPath;   
        fullPath = Application.dataPath + "/StreamingAssets";
        GameObject leftbutton_obj = GameObject.Find("LB");
        LB = leftbutton_obj.GetComponent<Button>();
        GameObject rightbutton_obj = GameObject.Find("RB");
        RB = rightbutton_obj.GetComponent<Button>();

        LB.onClick.AddListener(LB_click);
        RB.onClick.AddListener(RB_click);

        path = fullPath + "/" + DateTime.Today.ToString("yyyy-MM-dd") + ".txt";
        maketxt();

        
    }
    public void maketxt()
    {
        try
        {
            // 파일이 이미 존재하는지 확인
            if (!File.Exists(path))
            {
                // 파일이 없으면 새로운 파일을 생성하고 내용을 작성
                using (StreamWriter writer = File.CreateText(path))
                {
                    // writer.WriteLine("None");
                }

                Debug.Log(path +" 파일이 생성되었습니다.");
            }
            else
            {
                // 파일이 존재하면 내용을 읽어와서 줄 수와 내용을 출력
                string[] lines = File.ReadAllLines(path);
                // Debug.Log(path + " 파일이 이미 존재합니다. 파일 내용:");
                for (int i = 0; i < lines.Length; i++)
                {
                    Line = i+1;
                    Debug.Log($"파일이 이미 존재합니다. 줄:{Line}");
                    // Debug.Log("Line " + (i + 1) + ": " + lines[i]);
                }
            }
        }
        catch (System.Exception ex)
        {
            Debug.LogError("파일을 생성하는 도중 오류가 발생했습니다: " + ex.Message);
        }
    }

    void Update()
    {
        if (p_name != nameObj.name.ToString())
        {
            Debug.Log($"숫자 바뀜 {nameObj.name}");
            nameObj.name = p_name.ToString();
        }
        if (memo != memoObj.name.ToString())
        {
            Debug.Log($"문자 바뀜 {memoObj.name}");
            memoObj.name = memo.ToString();
        }
    }

    public void LB_click()
    {
        // Debug.Log("왼 됨");
        path = fullPath + "/" + mainScript.today.ToString("yyyy-MM-dd") + ".txt";

        maketxt();
    }
    public void RB_click()
    {
        // Debug.Log("오른 됨");
        path = fullPath + "/" + mainScript.today.ToString("yyyy-MM-dd") + ".txt";

        maketxt();
    }
}
