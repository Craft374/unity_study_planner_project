using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class B : MonoBehaviour
{
    private GameObject targetObject; // 변경된 오브젝트를 참조할 변수
    void Start()
    {
        // 변경된 오브젝트를 찾아서 변수에 할당
        targetObject = GameObject.Find("A");
    }

    void Update()
    {
        Debug.Log("1"+targetObject.name);
        Debug.Log("2"+gameObject.name);
        if (targetObject.name.ToString() == gameObject.name)
        {
            Debug.Log("같음");
        }
        else
        {
            Debug.Log("다름");
        }
    }
}

