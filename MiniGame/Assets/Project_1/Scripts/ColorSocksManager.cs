using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColorSocksManager : MonoBehaviour
{
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
                Debug.Log("hitObj : " + hit.transform.gameObject.name);
                if (hit.transform.tag == "ColorSocks")
                {
                    Socks socks = hit.transform.GetComponent<Socks>();
                    if (socks.isColorSocks)
                    {
                        socks.isClicked = true;
                    }
                }
            }
        }
    }
}
