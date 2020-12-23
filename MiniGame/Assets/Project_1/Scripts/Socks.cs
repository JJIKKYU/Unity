using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Socks : MonoBehaviour
{
    // 색상이 있는 양말인지 아닌지
    public bool isColorSocks;
    private float speed = 0.5f;

    private Rigidbody2D rigid;

    void Start()
    {
        rigid = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        
    }

    // 메인플레이어가 양말을 터치했을때 (색상이 있는 양말일 경우)
    public void ClickSocks()
    {
        if (!isColorSocks) return;
        Debug.Log("색상이 있는 양말입니다.");

    }

    // 메인플레이어가 양말을 스와이프 했을 때 (무채색 양말일 경우)
    public void SwipeSocks(Vector2 dir)
    {
        if (isColorSocks) return;
        Debug.Log("무채색 양말입니다");

        // 전달 받은 힘만큼 방향으로 이동
        rigid.AddForce(dir * speed, ForceMode2D.Impulse);
    }
}
