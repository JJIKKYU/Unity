using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Candy : MonoBehaviour, IDragHandler
{
    private bool isCollision = false;

    public Transform candyTargetTr;

    private float speed = 0.05f;

    // Start is called before the first frame update
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
        if (!isCollision) return;

        Vector2 destination = new Vector2(candyTargetTr.position.x, candyTargetTr.position.y);
        this.transform.position = Vector2.Lerp(this.transform.position, destination, speed);

        // 캔디의 방향에 맞춰서 회전
        Quaternion destinationQuaternion = Quaternion.Euler(0, 0, 50);
        this.transform.rotation = Quaternion.Lerp(this.transform.rotation, destinationQuaternion, Time.time * speed);
    }

    public void OnDrag(PointerEventData eventData)
    {
        if (isCollision) return;

        Vector3 touchPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);

        transform.position = new Vector2(touchPosition.x, touchPosition.y);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            this.isCollision = true;
        }
    }
}
