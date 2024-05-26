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
    private Button hideButton;
    private Image targetImage;

    void Start()
    {
        // HideButton 컴포넌트를 가져옵니다.
        hideButton = GetComponent<Button>();

        // 부모 오브젝트(Base) 내에서 이름이 'a'인 자식 오브젝트를 찾고, 
        // 그 Image 컴포넌트를 설정합니다.
        targetImage = FindTargetImage(transform.parent);

        // 버튼 클릭 이벤트에 메소드 등록
        if (hideButton != null)
        {
            hideButton.onClick.AddListener(OnHideButtonClick);
        }
    }

    // 부모 오브젝트 내에서 이름이 'a'인 Image 컴포넌트를 찾는 메소드
    private Image FindTargetImage(Transform parent)
    {
        foreach (Transform child in parent)
        {
            if (child.name == "a")
            {
                return child.GetComponent<Image>();
            }
        }
        return null;
    }

    void OnHideButtonClick()
    {
        Debug.Log("ojoiqwd");
        if (targetImage != null)
        {
            // 이미지 색을 변경합니다. (예: 투명하게 만들기)
            targetImage.color = new Color(0, 0, 0, 0); // 투명하게 설정
        }
    }
}

