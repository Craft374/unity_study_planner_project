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
    public GameObject clonedImage;
    public Button btn;
    void Start()
    {
        GameObject btnobj = GameObject.Find("qwer");
        btn = btnobj.GetComponent<Button>();
        btn.onClick.AddListener(btest);
        Debug.Log("asd");
        
    }
    public void btest()
    {
        Debug.Log("asdasdasd");
        originalImage = GameObject.Find("Image");
        clonedImage = Instantiate(originalImage);
        // Content 오브젝트를 찾아옵니다.
        GameObject content = GameObject.Find("Content");

        // 복제된 이미지를 Content의 자식으로 만듭니다.
        clonedImage.transform.SetParent(content.transform, false);
    }
}