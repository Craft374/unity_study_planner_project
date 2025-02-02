using System;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.UI;

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
    public int Line = 0;
    public buttontest btest;

    void Start()
    {
        Line = 0;

        nameObj = GameObject.Find("A");
        memoObj = GameObject.Find("B");

        p_name = nameObj.name.ToString();
        memo = memoObj.name.ToString();

        mainScript = GetComponent<main>();
        btest = GetComponent<buttontest>();

        // fullPath = Application.dataPath + "/StreamingAssets";
        fullPath = Application.persistentDataPath;
        GameObject leftbutton_obj = GameObject.Find("LB");
        LB = leftbutton_obj.GetComponent<Button>();
        GameObject rightbutton_obj = GameObject.Find("RB");
        RB = rightbutton_obj.GetComponent<Button>();

        LB.onClick.AddListener(LB_click);
        RB.onClick.AddListener(RB_click);

        path = fullPath + "/" + DateTime.Today.ToString("yyyy-MM-dd") + ".txt";
        // Debug.Log(path);
        maketxt();
    }

    public void maketxt()
    {
        try
        {
            if (!File.Exists(path))
            {
                using (StreamWriter writer = File.CreateText(path))
                {
                    // 초기 내용은 빈 파일로 생성
                }
                // Debug.Log(path + " 파일이 생성되었습니다.");
            }
            else
            {
                string[] lines = File.ReadAllLines(path);
                Line = lines.Length;
                // Debug.Log(path + " 파일이 이미 존재합니다. 줄 수: " + Line);
                btest.arise(Line);
                //btest.cloneIndex = 0;
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
            //Debug.Log($"숫자 바뀜 {nameObj.name}");
            nameObj.name = p_name.ToString();
        }
        if (memo != memoObj.name.ToString())
        {
            //Debug.Log($"문자 바뀜 {memoObj.name}");
            memoObj.name = memo.ToString();
        }
    }

    public void LB_click()
    {
        btest.cloneIndex = 0;

        path = fullPath + "/" + mainScript.today.ToString("yyyy-MM-dd") + ".txt";
        //saveText(21, "LB");
        maketxt(); 
    }

    public void RB_click()
    {
        btest.cloneIndex = 0;

        path = fullPath + "/" + mainScript.today.ToString("yyyy-MM-dd") + ".txt";
        //saveText(561, "RB");
        maketxt(); 
    }

    public void saveText(int lineNumber, string text, bool Yesno, bool onoff)
    {
        List<string> lines = new List<string>();

        if (File.Exists(path))
        {
            lines = new List<string>(File.ReadAllLines(path));
        }

        if (lineNumber < 1)
        {
            Debug.LogError("Line number is out of range.");
            return;
        }

        while (lines.Count < lineNumber)
        {
            lines.Add(string.Empty);
        }

        string prefix = $"{(Yesno ? 1 : 0)} {(onoff ? 1 : 0)} ";
        lines[lineNumber - 1] = prefix + text;

        File.WriteAllLines(path, lines.ToArray());

        Debug.Log($"{lineNumber}번째 줄이 {lines[lineNumber - 1]}로 변경되었습니다");
    }
}