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

    // 복제된 이미지의 인덱스
    private int cloneIndex = 0;

    void Start()
    {
        GameObject btnobj = GameObject.Find("addbtn");
        btn = btnobj.GetComponent<Button>();
        btn.onClick.AddListener(btest);
        Debug.Log("메모 추가 실행중");
    }

    public void btest()
    {
        Debug.Log("메모 추가");
        originalImage = GameObject.Find("base");
        GameObject content = GameObject.Find("Content");
        
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
