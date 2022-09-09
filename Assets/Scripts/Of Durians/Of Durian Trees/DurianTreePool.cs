using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Pool;

public class DurianTreePool : MonoBehaviour
{
    public GameObject durianTree, durianTreeOut;
    public int durianTreeAmountPooled;
    public ObjectPool<GameObject> durianTreePool;
    // Start is called before the first frame update
    void Awake()
    {
        durianTreePool = new ObjectPool<GameObject>(
            CreateDurianTreePool,
            durianTree => { durianTree.SetActive(true); },
            durianTree => { durianTree.SetActive(false); },
            durianTree => { Destroy(durianTree); },
            true, 200, 1000);


    }

    GameObject CreateDurianTreePool()
    {
        durianTreeOut = Instantiate(durianTree, Vector3.zero, Quaternion.identity);
        return durianTreeOut;
    }

    public GameObject GetDurianTrees()
    {
        durianTreeOut = durianTreePool.Get();
        return durianTreeOut;
    }

    public void ReleaseDurians(GameObject durianOut)
    {
        durianTreePool.Release(durianOut);
    }

}