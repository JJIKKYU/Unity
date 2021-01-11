using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Move2Player : MonoBehaviour
{

    private int touchCount = 0;
    private float speed = 0.1f;
    private float defaultSpeed = 0.05f;

    private Vector2 startPos;
    private Rigidbody2D rigid;

    // Start is called before the first frame update
    void Start()
    {
        startPos = transform.position;
        rigid = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log(Vector2.Distance(transform.position, startPos));
        if (Vector2.Distance(transform.position, startPos) > 0.1f)
        {
            //rigid.AddForce(Vector2.left * defaultSpeed, ForceMode2D.Impulse);
            transform.Translate(Vector2.left * Time.deltaTime * defaultSpeed);
        }


        touch();
    }

    private void touch()
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
                // 자신을 터치한 게 아니면 리턴
                if (hit.transform.gameObject != this.transform.gameObject) return;

                // 중앙 근처라면 움직이지 않도록
                if ((Vector2.Distance(new Vector2(0f, this.transform.position.y), this.transform.position) < 0.1f))
                {
                    transform.position = new Vector2(0f, this.transform.position.y);
                } else
                {
                    transform.position = new Vector2(transform.position.x + speed, transform.position.y);
                }
                touchCount += 1;
            }
        }
    }

}
