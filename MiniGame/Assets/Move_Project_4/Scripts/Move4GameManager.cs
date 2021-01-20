using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Move4GameManager : MonoBehaviour
{
    public GameObject obstacleBall;

    public ObjectPool objPool;

    private int score = 0;

    private int maxBallCount = 5;
    private int curBallCount = 0;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (curBallCount < maxBallCount)
        {
            ObstacleBall obj = objPool.obstacleBallObjPool.GetObject();
            obj.transform.position = new Vector2(Random.Range(-3f, 3f), 5.5f);
            obj.transform.rotation = Quaternion.identity;
            curBallCount += 1;
        }

    }

    public void ballCountDown()
    {
        if (curBallCount <= 0) return;
        curBallCount -= 1;
    }

    public void ballCountUp()
    {
        curBallCount += 1;
    }

    public void addScore(bool flag)
    {
        if (flag)
            score += 1;
        else
            score -= 1;
    }

    public void resetScore()
    {
        score = 0;
    }
}
