using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Socks : MonoBehaviour
{
    // 색상이 있는 양말인지 아닌지
    public bool isColorSocks;

    void Start()
    {
        
    }

    void Update()
    {
        
    }

    // 메인플레이어가 양말을 터치했을때 (색상이 있는 양말일 경우)
    void ClickSocks()
    {
        if (!isColorSocks) return;
        Debug.Log("색상이 있는 양말입니다.");

    }

    // 메인플레이어가 양말을 스와이프 했을 때 (무채색 양말일 경우)
    void SwipeSocks()
    {
        if (isColorSocks) return;
        Debug.Log("무채색 양말입니다");
    }
}
