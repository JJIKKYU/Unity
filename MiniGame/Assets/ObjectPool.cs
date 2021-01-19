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

    void Start()
    {
        bulletObjPool = new GenericObjectPool<bullet>(bulletPref, this.transform, 10);

    }

}
