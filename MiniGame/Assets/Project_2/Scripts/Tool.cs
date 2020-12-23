using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Tool : MonoBehaviour
{
    // 이동 타겟 목적지 오브젝트 트랜스폼
    public Transform targetTr;

    // 스와이프 했을 경우 속도
    public float swipeSpeed = 0.5f;
    // 가방 내부로 이동하는 속도
    public float destinationSpeed = 0.01f;

    // 가방과 근처에서 충돌했을 경우
    private bool isBagCollision = false;

    // 가방 안에서 멈추도록
    private bool isBagColliderCollision = false;


    private Vector2 startPos;
    private Vector2 endPos;
    private Transform target;
    private Vector2 dir;

    // Cache
    private Rigidbody2D rigid;
    private Transform bagTr;

    // Start is called before the first frame update
    void Start()
    {
        rigid = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        MoveInBag(dir);

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

                target = hit.transform;
                this.startPos = Input.mousePosition;
            }
        }
        // 마우스 클릭 (터치) 땔 경우
        else if (Input.GetMouseButtonUp(0))
        {
            if (!target) return;
            this.endPos = Input.mousePosition;
            Vector2 dir = (this.endPos - this.startPos).normalized;
            this.dir = dir;

            Move(dir);

            // 변수 초기화
            this.startPos = Vector2.zero;
            this.endPos = Vector2.zero;
            this.target = null;

        }

    }

    private void Move(Vector2 dir)
    {
        rigid.AddForce(dir * swipeSpeed, ForceMode2D.Impulse);
    }

    private void MoveInBag(Vector2 dir)
    {
        if (!isBagCollision) return;
        if (isBagColliderCollision) return;

        //Vector2 destination = new Vector2(this.transform.position.x, bagTr.position.y);
        //transform.position = Vector2.Lerp(transform.position, destination, destinationSpeed);

        rigid.AddForce(dir * swipeSpeed/2, ForceMode2D.Force);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Bag")
        {
            Debug.Log("Bag과 충돌했습니다");
            this.isBagCollision = true;
            bagTr = collision.GetComponent<Transform>();
        }

        if (collision.tag == "BagCollier")
        {
            this.isBagColliderCollision = true;
            this.gameObject.SetActive(false);
        }
    }
}
