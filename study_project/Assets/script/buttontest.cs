using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.IO;
using UnityEngine.Events;
using UnityEngine.Android;
using TMPro;

public class buttontest : MonoBehaviour
{
    public GameObject originalImage;
    public Button btn;
    public save saveScript;
    // 복제된 이미지의 인덱스
    private int cloneIndex = 0;
    public Button LB;
    public Button RB;

    void Start()
    {
        saveScript = GetComponent<save>(); 
        Debug.Log(saveScript.Line);

        GameObject btnobj = GameObject.Find("addbtn");
        btn = btnobj.GetComponent<Button>();
        btn.onClick.AddListener(btest);
        // Debug.Log("메모 추가 실행중");

        GameObject leftbutton_obj = GameObject.Find("LB");
        LB = leftbutton_obj.GetComponent<Button>();
        GameObject rightbutton_obj = GameObject.Find("RB");
        RB = rightbutton_obj.GetComponent<Button>();

        LB.onClick.AddListener(LB_click);
        RB.onClick.AddListener(RB_click);
    }

    public void btest()
    {   
        // Debug.Log("메모 추가");
        originalImage = GameObject.Find("base");
        GameObject content = GameObject.Find("Content");

        for (int i = 0; i < 1/*이 앞에 숫자가 몇번 생성 되는지 보는거임*/; i++)
        {
            // 오브젝트 복제
            GameObject clonedImage = Instantiate(originalImage);

            // 복제된 오브젝트 이름 설정
            clonedImage.name = (cloneIndex + 1).ToString();
            cloneIndex++;

            // 복제된 이미지를 Content의 자식으로 만듭니다.
            clonedImage.transform.SetParent(content.transform, false);

            // 원래 오브젝트 다음에 배치
            clonedImage.transform.SetSiblingIndex(originalImage.transform.GetSiblingIndex() + 1);
        }
    }

    public void LB_click()
    {
        originalImage = GameObject.Find("base");
        GameObject content = GameObject.Find("Content");
        int n = 0;
        while (n < 2)
        {
            if (saveScript.Line != 0)
            {
                for (int i = 0; i < saveScript.Line/*이 앞에 숫자가 몇번 생성 되는지 보는거임*/; i++)
                {
                    // 오브젝트 복제
                    GameObject clonedImage = Instantiate(originalImage);

                    // 복제된 오브젝트 이름 설정
                    clonedImage.name = (cloneIndex + 1).ToString();
                    cloneIndex++;

                    // 복제된 이미지를 Content의 자식으로 만듭니다.
                    clonedImage.transform.SetParent(content.transform, false);

                    // 원래 오브젝트 다음에 배치
                    clonedImage.transform.SetSiblingIndex(originalImage.transform.GetSiblingIndex() + 1);
                }
            }
        }
            
               
    }
    
    public void RB_click()
    {
        // Debug.Log("오른 됨");
        // path = fullPath + "/" + mainScript.today.ToString("yyyy-MM-dd") + ".txt";

        // maketxt();
    }
}
