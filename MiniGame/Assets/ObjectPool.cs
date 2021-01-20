using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPool : MonoBehaviour
{

    // Singletone
    private static ObjectPool instance;

    void Awake()
    {
        if (!instance)
        {
            instance = this;
            //DontDestroyOnLoad(this.gameObject);
        }
        else
            Destroy(this.gameObject);
    }

    public static ObjectPool Instance
    {
        get
        {
            if (!instance)
                return null;
            return instance;
        }
    }

    ///////////////////////

    [SerializeField] private bullet bulletPref;
    public GenericObjectPool<bullet> bulletObjPool;

    [SerializeField] private ObstacleBall obstacleBallPref;
    public GenericObjectPool<ObstacleBall> obstacleBallObjPool;

    void Start()
    {
        if (bulletPref) 
            bulletObjPool = new GenericObjectPool<bullet>(bulletPref, this.transform, 10);

        if (obstacleBallPref)
            obstacleBallObjPool = new GenericObjectPool<ObstacleBall>(obstacleBallPref, this.transform, 10);

    }

}
