using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.IO;
using UnityEngine.Events;
using UnityEngine.Android;
using TMPro;


public class onoff : MonoBehaviour
{
    public Button btn;
    public TMP_InputField inputField;
    public string p_name;
    public string memo;
    private GameObject nameObj;
    private GameObject memoObj;
    public TMP_Text qwe;
    public save saveScript;
    public main mainScript;
    public string fullPath; 
    public string path;

    private List<string> ooo = new List<string>();
    public void Start()
    {

        GameObject saveobj = GameObject.Find("Main Camera");
        saveScript = saveobj.GetComponent<save>();   
        mainScript = saveobj.GetComponent<main>();

        p_name = "";
        memo = "";
        nameObj = GameObject.Find("A");
        memoObj = GameObject.Find("B");

        // GameObject qwe_obj = GameObject.Find("qwe");
        // qwe = qwe_obj.GetComponent<TMP_Text>();

        inputField = FindTargetInputField(transform.parent);
        btn = GetComponent<Button>();
        if (btn != null)
        {
            btn.onClick.AddListener(OnButtonClicked);
        }
        if (inputField != null)
        {
            inputField.onEndEdit.AddListener(OnEndEdit);
        }
        int parentName = int.Parse(transform.parent.name);
        //Debug.Log(parentName);
        fullPath = Application.dataPath + "/StreamingAssets";
        path = fullPath + "/" + mainScript.today.ToString("yyyy-MM-dd") + ".txt";
        LoadDataFromFile();
        int index = int.Parse(parentName.ToString()) - 1;
        if (index >= 0 && index < ooo.Count)
        {
            inputField.text = ooo[index];
        }
        else
        {
            inputField.text = ""; // 또는 기본값 설정
            Debug.LogWarning($"Index {index} is out of range for ooo list.");
        }
    }

    private void LoadDataFromFile()
    {
        ooo.Clear(); // 기존 리스트 초기화

        if (File.Exists(path))
        {
            string[] lines = File.ReadAllLines(path);
            foreach (string line in lines)
            {
                ooo.Add(line);
            }
        }
        else
        {
            Debug.LogWarning("File not found: " + path);
        }
            PrintList();
    }

    void InsertTextAt(int index, string text)
    {
        if (index < 0)
        {
            Debug.LogError("Index cannot be negative.");
            return;
        }

        // 리스트의 크기가 인덱스를 포함할 수 있도록 확장
        while (ooo.Count <= index)
        {
            ooo.Add("");
        }

        // 인덱스에 텍스트 삽입
        ooo[index] = text;
        Debug.Log($"{ooo[index]}");
    }

    void PrintList()
    {
        for (int i = 0; i < ooo.Count; i++)
        {
            Debug.Log($"Element at {i}: {ooo[i]}");
        }
    }
    private TMP_InputField FindTargetInputField(Transform parent)
    {
        foreach (Transform child in parent)
        {
            if (child.name == "ININ")
            {
                return child.GetComponent<TMP_InputField>();
            }
        }
        return null;
    }

    public void OnEndEdit(string value)
    {
        if (!inputField.isFocused)
        {
            Debug.Log("입력 안함ㅋ");
            p_name = transform.parent.name.ToString();
            memo = value.ToString();
            Debug.Log(p_name + " " + memo);
            
            InsertTextAt(1, memo);
            Debug.Log($"{ooo[1]}");
            nameObj.name = p_name;
            memoObj.name = memo;
            // qwe.text = "asd";
            if (saveScript != null)
            {
                saveScript.saveText(int.Parse(p_name), memo);
            }
            else
            {
                Debug.LogError("Save 스크립트를 찾을 수 없습니다.");
            }
            
        }
    }

    public void OnButtonClicked()
    {
        Debug.Log("입력중ㅋ");
        inputField.ActivateInputField();
        //inputField.text = ooo[1]; //인풋필드 내용 변경
    }
}

