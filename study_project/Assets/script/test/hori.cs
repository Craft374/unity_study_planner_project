using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.IO;
using UnityEngine.Events;
using UnityEngine.Android;
using TMPro;

using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System;

public class hori : MonoBehaviour
{
    public GameObject baseObject;
    public float spacing = 10f; // 각 오브젝트 사이의 간격

    void Start()
    {
        GenerateCalendar();
    }

    void GenerateCalendar()
    {
        int daysInMonth = DateTime.DaysInMonth(DateTime.Now.Year, DateTime.Now.Month);
        RectTransform contentRectTransform = baseObject.transform.parent.GetComponent<RectTransform>();
        float totalWidth = 0f;

        for (int day = 1; day <= daysInMonth; day++)
        {
            GameObject newDay = Instantiate(baseObject, baseObject.transform.parent);
            newDay.name = day.ToString();

            TextMeshProUGUI tmpText = newDay.GetComponentInChildren<TextMeshProUGUI>();
            if (tmpText != null)
            {
                tmpText.text = day.ToString();
            }

            RectTransform rectTransform = newDay.GetComponent<RectTransform>();
            rectTransform.anchoredPosition = new Vector2(totalWidth, 0);
            
            totalWidth += rectTransform.rect.width + spacing;
            
            newDay.SetActive(true);
        }

        // content의 너비를 총 크기에 맞게 조절
        contentRectTransform.SetSizeWithCurrentAnchors(RectTransform.Axis.Horizontal, totalWidth);

        baseObject.SetActive(false);

        // 필요한 경우 ScrollRect 컴포넌트의 horizontal 속성을 true로 설정
        ScrollRect scrollRect = contentRectTransform.GetComponentInParent<ScrollRect>();
        if (scrollRect != null)
        {
            scrollRect.horizontal = true;
        }
    }
}