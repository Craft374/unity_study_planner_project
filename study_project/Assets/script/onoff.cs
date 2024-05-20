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
    // Start is called before the first frame update
    public void Start()
    {
        GameObject btnobj = GameObject.Find("hide");
        GameObject inputobj = GameObject.Find("ININ");
        inputField = inputobj.GetComponent<TMP_InputField>();
        btn = btnobj.GetComponent<Button>();
        btn.onClick.AddListener(OnButtonClicked);
        inputField.onEndEdit.AddListener(OnEndEdit);
        Debug.Log("실행중");
    }
    public void OnEndEdit(string value)
    {
        if (!inputField.isFocused)
        {
            Debug.Log("입력 안함ㅋ");
        }
    }

    public void OnButtonClicked()
    {
        Debug.Log("입력중ㅋ");
        inputField.ActivateInputField();
    }
}
// 에딧 누르면 수정 -> 하이드 누르면 수정으로
