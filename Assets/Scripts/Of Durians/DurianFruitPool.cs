using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Pool;

public class DurianFruitPool : MonoBehaviour
{
    public GameObject durianFruit, durianOut;
    public int durianAmountPooled;
    public ObjectPool<GameObject> durianPool;
    // Start is called before the first frame update
    void Awake()
    {
        durianPool = new ObjectPool<GameObject>(
            CreateDurianPool ,
            durianFruit => { durianFruit.SetActive(true); },
            durianFruit => { durianFruit.SetActive(false); },
            durianFruit => { Destroy(durianFruit); },
            true, 200, 1000);

       
    }

    GameObject CreateDurianPool()
    {
        durianOut = Instantiate(durianFruit, Vector3.zero, Quaternion.identity);
        return durianOut;
    }

    public GameObject GetDurians()
    {
        durianOut = durianPool.Get();
        return durianOut;
    }

    public void ReleaseDurians(GameObject durianOut)
    {
        durianPool.Release(durianOut);
    }

}
