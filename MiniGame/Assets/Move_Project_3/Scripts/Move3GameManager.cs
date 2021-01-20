using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Move3GameManager : MonoBehaviour
{
    public Obstacle obstacle;
    public Move2Player player;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Vector2.Distance(player.transform.position, obstacle.transform.position) < 0.1f)
        {
            Debug.Log("가깝습니다");
            player.touchCountDown();
        }
    }
}
