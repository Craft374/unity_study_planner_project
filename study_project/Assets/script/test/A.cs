using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class A : MonoBehaviour
{
    private GameObject targetObject; // 타겟 오브젝트를 참조할 변수

    void Start()
    {
        // 타겟 오브젝트를 찾아서 변수에 할당
        targetObject = GameObject.Find("A");
        if (targetObject == null)
        {
            Debug.LogError("타겟 오브젝트를 찾을 수 없습니다.");
        }
    }

    void Update()
    {
        // 예시로 5초 후에 타겟 오브젝트의 이름을 변경하는 코드
        if (Time.time >= 5f)
        {
            ChangeObjectName();
        }
    }

    // 타겟 오브젝트의 이름을 변경하는 메서드
    void ChangeObjectName()
    {
        if (targetObject != null)
        {
            targetObject.name = "NewObjectName";
        }
    }
}

