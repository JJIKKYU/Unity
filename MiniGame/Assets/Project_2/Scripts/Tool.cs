using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Tool : MonoBehaviour, IDragHandler
{
    // 이동 타겟 목적지 오브젝트 트랜스폼
    public Transform targetTr;

    // 스와이프 했을 경우 속도
    public float swipeSpeed = 0.5f;
    // 가방 내부로 이동하는 속도
    public float destinationSpeed = 0.01f;

    // 가방과 근처에서 충돌했을 경우
    private bool isBagCollision = false;

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
        MoveInBag();
    }

    private void Move(Vector2 dir)
    {
        rigid.AddForce(dir * swipeSpeed, ForceMode2D.Impulse);
    }

    private void MoveInBag()
    {
        if (!isBagCollision) return;

        Vector2 destination = new Vector2(this.transform.position.x, bagTr.position.y);
        transform.position = Vector2.Lerp(transform.position, destination, destinationSpeed);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Bag")
        {
            Debug.Log("Bag과 충돌했습니다");
            this.isBagCollision = true;
            bagTr = collision.GetComponent<Transform>();
        }
    }

    public void OnDrag(PointerEventData eventData)
    {
        if (this.isBagCollision) return;
        Debug.Log("이동중");
        Vector3 touchPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);

        transform.position = new Vector2(touchPosition.x, touchPosition.y);
    }
}
