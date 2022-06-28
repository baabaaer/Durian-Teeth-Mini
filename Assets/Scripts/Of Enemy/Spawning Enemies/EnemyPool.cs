using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Pool;

public class EnemyPool : MonoBehaviour
{
    public GameObject enemy, enemyOut;
    public int enemyAmountPooled;
    public ObjectPool<GameObject> enemyPool;
    // Start is called before the first frame update
    void Awake()
    {
        enemyPool = new ObjectPool<GameObject>(
            CreateDurianPool,
            enemy => { enemy.SetActive(true); },
            enemy => { enemy.SetActive(false); },
            enemy => { Destroy(enemy); },
            true, 200, 1000);


    }

    GameObject CreateDurianPool()
    {
        enemyOut = Instantiate(enemy, Vector3.zero, Quaternion.identity);
        return enemyOut;
    }

    public GameObject GetDurians()
    {
        enemyOut = enemyPool.Get();
        return enemyOut;
    }

    public void ReleaseDurians(GameObject durianOut)
    {
        enemyPool.Release(enemyOut);
    }

    // Update is called once per frame

}