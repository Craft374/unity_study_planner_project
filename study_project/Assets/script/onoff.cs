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


    private List<string> ooo = new List<string>();
    public void Start()
    {

        GameObject saveobj = GameObject.Find("Main Camera");
        saveScript = saveobj.GetComponent<save>();   


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
        string parentName = transform.parent.name;
        Debug.Log(parentName);

        ooo.Add("First");
        ooo.Add("Second");
        ooo.Add("Third");

        // 리스트의 특정 인덱스에 값을 넣는 함수 호출
        InsertTextAt(1, "NewText");
        
        // 리스트 출력
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

            nameObj.name = p_name;
            memoObj.name = memo;
            //qwe.text = memo;
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
        //inputField.text = memoObj.name;
    }
}

