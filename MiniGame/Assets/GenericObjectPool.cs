using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GenericObjectPool<T> where T : Component
{
    // Singletone
    private static GenericObjectPool<T> instance;

    void Awake()
    {
        // Initialize(10);

        if (instance == null)
        {
            instance = this;
        }
    }

    public static GenericObjectPool<T> Instance
    {
        get
        {
            if (instance == null)
                return null;
            return instance;
        }
    }

    ///////////////////////


    private Queue<T> objectPool;
    private T objPref;
    private Transform parent;
    private Vector3 initPosition = new Vector3(0f, 40f, 0f);
    private int count;

    public GenericObjectPool(T objPref, Transform parent, int count)
    {
        this.objPref = objPref;
        this.parent = parent;
        this.objectPool = new Queue<T>(count);
        this.count = count;
        Initialize(count);
    }

    public void Initialize(int count)
    {
        for (int i = 0; i < count; ++i)
        {
            T obj = GameObject.Instantiate<T>(objPref, initPosition, objPref.transform.rotation);
            obj.gameObject.SetActive(false);
            obj.transform.SetParent(parent);
            objectPool.Enqueue(obj);
        }
    }

    public T GetObject()
    {
        if (objectPool.Count <= 0)
        {
            Debug.Log("오브젝트 풀의 크기보다 더 많은 오브젝트를 호출하여 추가로 생성합니다.");
            CreateObj();
        }
        T obj = objectPool.Dequeue();
        obj.transform.SetParent(null);
        obj.gameObject.SetActive(true);
        return obj;
    }

    public void ReturnObject(T obj)
    {
        obj.transform.position = initPosition;
        obj.gameObject.SetActive(false);
        obj.transform.SetParent(parent);
        objectPool.Enqueue(obj);
    }

    private void CreateObj()
    {
        for (int i = 0; i < count; ++i)
        {
            T obj = GameObject.Instantiate<T>(objPref, initPosition, objPref.transform.rotation);
            obj.gameObject.SetActive(false);
            obj.transform.SetParent(parent);
            objectPool.Enqueue(obj);
        }
    }
}


