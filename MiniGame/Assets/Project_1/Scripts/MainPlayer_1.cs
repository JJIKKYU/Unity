﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainPlayer_1 : MonoBehaviour
{

    // 터치 다운 포지션
    private Vector2 startPos;
    // 터치 업 포지션
    private Vector2 endPos;
    // 터치했을 경우 타겟
    private Socks target;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        // 마우스 클릭 (터치) 할 경우
        if (Input.GetMouseButtonDown(0))
        {
            // 마우스 클릭(터치) 한 포지션을, 2D 월드 포지션으로 변환
            Vector3 touchPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            // 클릭한 마우스 위치에서 레이캐스트에 걸리는 물체를 hit으로 가져온다
            RaycastHit2D hit = Physics2D.Raycast(touchPosition, transform.forward, 15f);
            if (hit)
            {
                Socks target = hit.transform.GetComponent<Socks>();
                if (!target) return;

                // 유채색 양말일 경우
                if (target.isColorSocks)
                {
                    // 터치해서 움직이도록
                    target.ClickSocks();
                }
                // 무채색 양말일 경우
                else
                {
                    // 스와이프해서 움직이기 위해서 현재 마우스 포지션 저장
                    this.startPos = Input.mousePosition;
                    this.target = target;
                }
                
                

            }
        }
        // 마우스 클릭 (터치) 땔 경우
        else if (Input.GetMouseButtonUp(0))
        {
            // 타겟이 없으면 무채색 양말이 아닌 경우 이므로
            if (!target) return;

            // 유채색 양말일 경우
            this.endPos = Input.mousePosition;
            // 터치 시작과 끝 디렉션 벡터 정규화
            Vector2 dir = (this.endPos - this.startPos).normalized;
            Debug.Log("swipeDir = " + dir);
            // 정규화한 방향을 오브젝트에게 넘겨줘서 이동하도로
            target.SwipeSocks(dir);

            // 움직이도록 하고 변수 초기화
            this.target = null;
            this.startPos = Vector2.zero;
            this.endPos = Vector2.zero;
        }

        
    }
}