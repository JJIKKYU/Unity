using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Socks : MonoBehaviour, IDragHandler
{
    // 색상이 있는 양말인지 아닌지
    public bool isColorSocks;
    // 유채색 양말 스피드
    public float colorSocksSpeed = 0.05f;

    /*
     * 유채색 양말 변수
     */
    public Transform targetPosition;
    // 유채색 양말이 클릭이 되었는지 체크
    public bool isClicked = false;
    

    void Start()
    {
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

    // TargetPosition GameObject로 이동
    private void Move()
    {
        if (!isClicked) return;

        transform.position = Vector2.Lerp(transform.position, targetPosition.position, colorSocksSpeed);
    }

    // 무채색 양말 드래ㄱ
    public void OnDrag(PointerEventData eventData)
    {
        // 유채색 양말은 드래그하지 않음
        if (isColorSocks) return;

        Debug.Log("이동중");
        Vector3 touchPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);

        transform.position = new Vector2(touchPosition.x, touchPosition.y);
    }
}
