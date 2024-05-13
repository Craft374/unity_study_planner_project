using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.IO;
using UnityEngine.Events;
using UnityEngine.Android;
using TMPro;

public class asdf : MonoBehaviour
{
    public GameObject basePrefab;
    public Button mainButton;
    public GameObject aButtonPrefab;
    public GameObject bImagePrefab;
    private int count = 0;

    void Start()
    {
        mainButton.onClick.AddListener(OnMainButtonClicked);
    }

    void OnMainButtonClicked()
    {
        count++;
        GameObject newBase = Instantiate(basePrefab, new Vector3(0, count * 2, 0), Quaternion.identity);
        newBase.name = "base" + count;

        // A 버튼 생성
        GameObject newAButton = Instantiate(aButtonPrefab, newBase.transform);
        newAButton.name = "A" + count + "Button";
        newAButton.GetComponent<Button>().onClick.AddListener(() => OnAButtonClicked(newBase.transform));

        // B 이미지 생성
        GameObject newBImage = Instantiate(bImagePrefab, newBase.transform);
        newBImage.name = "B" + count + "Image";
    }

    public void OnAButtonClicked(Transform baseTransform)
    {
        GameObject bImage = baseTransform.Find("B" + baseTransform.name.Substring(4) + "Image").gameObject;
        bImage.SetActive(false);
    }
}
