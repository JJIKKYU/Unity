using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Cup : MonoBehaviour, IDragHandler
{
    // 물을 따르는 목표치
    private float destinationWater = 100f;
    // 물을 따르는 속도
    private float speed = 12f;
    // 현재 물이 찬 정도
    private float currentWater = 0f;
    // 여유값(오차값)
    private float errorValue = 2f;

    private float currentTime;

    private bool isCollision = false;

    // 물따르기 게임이 끝났는지 체크
    private bool isComplete = false;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        PourWater();
    }

    // 물을 따르는 함수
    private void PourWater()
    {
        if (!isCollision) return;
        if (isComplete) return;
        // 현재 물이 목표한 물보다 많으면 게임이 실패이므로, waterCheck함수를 호출해 게임 종료
        // 1f를 더한 이유는, errorValue(여유분)까지 포함해서 게임 승리 판정을 하므로  
        if (currentWater > destinationWater + errorValue + 1f)
        {
            WaterCheck();
            return;
        }

        currentTime += Time.deltaTime;
        Debug.Log(currentTime + "초 , " + "현재 물의 양 : " + currentWater);

        currentWater += speed * Time.deltaTime;
    }

    // 물의 양 오차 체크
    private void WaterCheck()
    {
        if (isComplete) return;
        // 현재 물이 목표치(여유분) 보다 작을 경우에는 더 물을 넣을 수 있도록 리턴
        if (currentWater < destinationWater - errorValue) return;

        float currentErrorValue = Mathf.Abs(destinationWater - currentWater);

        if (currentErrorValue < errorValue)
        {
            Debug.Log(currentErrorValue + "값이" + errorValue + "보다 작으므로 성공했습니다.");
            isComplete = true;
        }
        else
        {
            Debug.Log(currentErrorValue + "값이" + errorValue + "보다 크므로 실패했습니다.");
            isComplete = true;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Destination")
        {
            // 오브젝트에 최초 충돌시 flag를 true로 변경
            isCollision = true;
            
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == "Destination")
        {
            // 유저가 드래그하다가, 해당 오브젝트 바깥으로 나갈 경우 타이머 체크 flag 해제 
            isCollision = false;
            Debug.ClearDeveloperConsole();
            Debug.Log(currentTime);
            WaterCheck();
        }
    }

    public void OnDrag(PointerEventData eventData)
    {
        Vector3 touchPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);

        transform.position = new Vector2(touchPosition.x, touchPosition.y);
    }
}
