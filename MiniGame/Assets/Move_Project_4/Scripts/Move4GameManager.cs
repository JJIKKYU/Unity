using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Move4GameManager : MonoBehaviour
{
    public GameObject obstacleBall;
    public int ballCount;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log("현재 볼 카운트 = " + ballCount);
        touch();
    }

    private void touch()
    {
        // 마우스 클릭 (터치) 할 경우
        if (Input.GetMouseButtonDown(0))
        {
            Instantiate(obstacleBall, new Vector2(Random.Range(-3f, 3f), 5.5f), Quaternion.identity);
        }
    }
}
