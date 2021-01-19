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

    public ObjectPool objPool;
    public GenericObjectPool<bullet> usingObjPool;


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
            bullet obj = objPool.bulletObjPool.GetObject();
            obj.transform.position = pos;
            obj.transform.rotation = Quaternion.identity;            
            curInstantiateCount += 1;
        }
        
    }

    public void bulletCountUp(bullet obj)
    {
        objPool.bulletObjPool.ReturnObject(obj);
        bulletCount += 1;
        curInstantiateCount -= 1;
        Debug.Log("현재 파괴된 총알의 개수는 " + bulletCount + "입니다");
    }

    public void destoryBullet(bullet obj)
    {
        objPool.bulletObjPool.ReturnObject(obj);
        curInstantiateCount -= 1;
    }

}
