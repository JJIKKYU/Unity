using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Socks : MonoBehaviour, IDragHandler
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
        detectTouch();
        Move();
    }

    private void detectTouch()
    {
        if (!isColorSocks) return;

        // 마우스 클릭 (터치) 할 경우
        if (Input.GetMouseButtonDown(0))
        {
            // 마우스 클릭(터치) 한 포지션을, 2D 월드 포지션으로 변환
            Vector3 touchPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            // 클릭한 마우스 위치에서 레이캐스트에 걸리는 물체를 hit으로 가져온다
            RaycastHit2D hit = Physics2D.Raycast(touchPosition, transform.forward, 15f);
            if (hit)
            {
                // 자신을 터치한 게 아니면 리턴
                if (hit.transform.gameObject != this.transform.gameObject) return;

                // 유채색 양말일 경우
                if (isColorSocks)
                {
                    this.isClicked = true;
                }
            }
        }
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

    public void OnDrag(PointerEventData eventData)
    {
        // 유채색 양말은 드래그하지 않음
        if (isColorSocks) return;

        Debug.Log("이동중");
        Vector3 touchPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);

        transform.position = new Vector2(touchPosition.x, touchPosition.y);
    }
}
