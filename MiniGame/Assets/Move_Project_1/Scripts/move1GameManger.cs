using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class move1GameManger : MonoBehaviour
{
    public GameObject bullet;

    private int maxInstantiateCount = 3;
    private int curInstantiateCount = 0;
    public Vector2 instantiatePos;

    private int bulletCount;
    

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (curInstantiateCount < maxInstantiateCount)
        {
            Vector2 pos = new Vector2(instantiatePos.x, instantiatePos.y + Random.Range(-3, 3));
            GameObject obj = Instantiate(bullet, pos, Quaternion.identity);
            curInstantiateCount += 1;
        }
        
    }

    public void bulletCountUp()
    {
        bulletCount += 1;
        curInstantiateCount -= 1;
        Debug.Log("현재 파괴된 총알의 개수는 " + bulletCount + "입니다");
    }

    public void destoryBullet()
    {
        curInstantiateCount -= 1;
    }

}
