using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.IO;
using UnityEngine.Events;
using UnityEngine.Android;
using TMPro;
using UnityEngine.EventSystems; 
using System.Linq;


public class onoff : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
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

    private bool isPressed = false;
    private float pressStartTime;
    private float longPressDuration = 0.5f;
    private Coroutine longPressCoroutine;

    private List<string> ooo = new List<string>();
    private bool Yesno; //이거는 나중에 꾹눌러서 삭제했을때 판단 이게 1이면 있는거고 0이면 없애면됨
    private bool OX; //OX기능 했나 안했나를 판단
    private int index;

    public void Start()
    {
        if (!Permission.HasUserAuthorizedPermission(Permission.ExternalStorageRead))
        {
            Permission.RequestUserPermission(Permission.ExternalStorageRead);
        }
        if (!Permission.HasUserAuthorizedPermission(Permission.ExternalStorageWrite))
        {
            Permission.RequestUserPermission(Permission.ExternalStorageWrite);
        }
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

        int parentName;
        if (int.TryParse(transform.parent.name, out parentName))
        {
            // 파싱 성공 시 처리
            // Debug.Log(parentName);
        }
        else
        {
            // 파싱 실패 시 처리
            // Debug.LogWarning("Parent name is not a valid integer: " + transform.parent.name);
            parentName = 0; // 또는 다른 기본값 설정
        }

        // fullPath = Application.dataPath + "/StreamingAssets";
        fullPath = Application.persistentDataPath;
        path = fullPath + "/" + mainScript.today.ToString("yyyy-MM-dd") + ".txt";
        LoadDataFromFile();

        index = int.Parse(parentName.ToString()) - 1;
        if (index >= 0 && index < ooo.Count)
        {
            // inputField.text = ooo[index];
            inputField.text = string.Join(" ", ooo[index].Split(' ').Skip(2));

        }
        else
        {
            inputField.text = ""; // 또는 기본값 설정
            // Debug.LogWarning($"Index {index} is out of range for ooo list.");
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

            if (index >= 0 && index < ooo.Count)
            {
                string[] parts = ooo[index].Split(' ');

                if (parts.Length > 2)
                {
                    Yesno = parts[0] == "1";
                    OX = parts[1] == "1";
                    Debug.Log($"활성화 여부: {Yesno}, OX여부: {OX}");
                }
            }
        }
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
        // Debug.Log($"{ooo[index]}");
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
            // Debug.Log(p_name + " " + memo);
            
            InsertTextAt(1, memo);
            nameObj.name = p_name;
            memoObj.name = memo;
            // qwe.text = "asd";
            if (saveScript != null)
            {
                saveScript.saveText(int.Parse(p_name), memo, true, true);
            }
            else
            {
                Debug.LogError("Save 스크립트를 찾을 수 없습니다.");
            }
            
        }
    }

    public void OnButtonClicked()
    {
        if (Time.time - pressStartTime <= longPressDuration)
        {
            Debug.Log("입력중");
            inputField.ActivateInputField();
        }
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        isPressed = true;
        pressStartTime = Time.time;
        longPressCoroutine = StartCoroutine(CheckLongPress());
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        isPressed = false;
        if (longPressCoroutine != null)
        {
            StopCoroutine(longPressCoroutine);
        }
    }

    private IEnumerator CheckLongPress()
    {
        while (isPressed)
        {
            if (Time.time - pressStartTime > longPressDuration)
            {
                Debug.Log("꾹 누르고 있습니다.");
                Destroy(transform.parent.gameObject);
                yield break;
            }
            yield return null;
        }
    }
}

