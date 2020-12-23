using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Socks : MonoBehaviour
{
    // 색상이 있는 양말인지 아닌지
    public bool isColorSocks;

    // 무채색 양말 스피드
    private float achromaticColorSocksSpeed = 0.5f;
    // 유채색 양말 스피드
    public float colorSocksSpeed = 0.05f;

    /*
     * 유채색 양말 변수
     */
    public Transform targetPosition;
    // 유채색 양말이 클릭이 되었는지 체크
    private bool isClicked = false;
    

    // 캐시
    private Rigidbody2D rigid;

    void Start()
    {
        rigid = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        Move();
    }

    // 메인플레이어가 양말을 터치했을때 (색상이 있는 양말일 경우)
    public void ClickSocks()
    {
        if (!isColorSocks) return;
        Debug.Log("색상이 있는 양말입니다.");
        this.isClicked = true;
    }

    private void Move()
    {
        if (!isClicked) return;

        transform.position = Vector2.Lerp(transform.position, targetPosition.position, colorSocksSpeed);
    }

    // 메인플레이어가 양말을 스와이프 했을 때 (무채색 양말일 경우)
    public void SwipeSocks(Vector2 dir)
    {
        if (isColorSocks) return;
        Debug.Log("무채색 양말입니다");

        // 전달 받은 힘만큼 방향으로 이
        rigid.AddForce(dir * achromaticColorSocksSpeed, ForceMode2D.Impulse);
    }
}
