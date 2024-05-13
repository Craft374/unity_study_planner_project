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
    public GameObject makja;
    public TMP_InputField inputField;
    // Start is called before the first frame update
    void Start()
    {
        GameObject btnobj = GameObject.Find("edit");
        GameObject inputobj = GameObject.Find("ININ");
        inputField = inputobj.GetComponent<TMP_InputField>();
        btn = btnobj.GetComponent<Button>();
        btn.onClick.AddListener(OnButtonClicked);
        makja = GameObject.Find("makja");
        makja.SetActive(true);
        inputField.onEndEdit.AddListener(OnEndEdit);
        Debug.Log("실행중");
    }
    private void OnEndEdit(string value)
    {
        if (!inputField.isFocused)
        {
            makja.SetActive(true);
            Debug.Log("입력 안함ㅋ");
        }
    }

    private void OnButtonClicked()
    {
        Debug.Log("입력중ㅋ");
        inputField.ActivateInputField();
        makja.SetActive(false);
    }
}
