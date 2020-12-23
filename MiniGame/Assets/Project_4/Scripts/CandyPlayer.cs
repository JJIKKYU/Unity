using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class CandyPlayer : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler
{
    public Transform candyObj;
    // 캔디 위치
    public Transform candyTargetTr;
    // 캔디가 이동하는 속도
    private float speed = 0.05f;
    // 캔디가 회전하는 속도
    private float rotationSpeed = 0.05f;

    // 목표 스와이프 횟수
    private int maxSwipeCnt = 3;
    // 현재 스와이프 수
    private int currentSwipeCnt = 0;
    // 스와이프로 인정할 거리
    private float destinationSwipeDistance = 1.5f;

    private Vector3 beforeTouchPosition = Vector3.zero;

    private bool isLeftToRight = false;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Move();
    }

    private void Move()
    {
        if (currentSwipeCnt < maxSwipeCnt) return;

        Vector2 destination = new Vector2(candyTargetTr.position.x, candyTargetTr.position.y);
        candyObj.position = Vector2.Lerp(candyObj.position, destination, speed);

        // 캔디의 방향에 맞춰서 회전
        Quaternion destinationQuaternion = Quaternion.Euler(0, 0, 50);
        candyObj.rotation = Quaternion.Lerp(candyObj.rotation, destinationQuaternion, Time.time * rotationSpeed);
    }

    public void OnBeginDrag(PointerEventData eventData)
    {
        Vector3 touchPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        beforeTouchPosition = touchPosition;

        Debug.Log("터치 시작");
    }

    public void OnDrag(PointerEventData eventData)
    {
        Vector3 touchPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        float distance = Vector3.Distance(beforeTouchPosition, touchPosition);
        float direction = (touchPosition - beforeTouchPosition).normalized.x;

        // 목표한 스와이프 거리보다 높아질 경우
        if (distance > destinationSwipeDistance)
        {
            // 오른쪽에서 왼쪽으로 스와이프 할 경우
            if (direction < 0f && isLeftToRight)
            {
                Debug.Log("왼쪽에서 오른쪽으로 이동하세요");
                beforeTouchPosition = touchPosition;
                isLeftToRight = false;
                currentSwipeCnt += 1;
            }
            // 왼쪽에서 오른쪽으로 스와이프 할 경우
            else if (direction > 0f && !isLeftToRight)
            {
                Debug.Log("오른쪽에서 왼쪽으로 이동하세요");
                beforeTouchPosition = touchPosition;
                isLeftToRight = true;
                currentSwipeCnt += 1;
            }
        }
        Debug.Log("distance: " + distance + ", direction : " + (direction > 0f ? 0 : -1) + ", currentSwipeCnt : " + currentSwipeCnt);

    }

    public void OnEndDrag(PointerEventData eventData)
    {
        beforeTouchPosition = Vector3.zero;
    }
}
