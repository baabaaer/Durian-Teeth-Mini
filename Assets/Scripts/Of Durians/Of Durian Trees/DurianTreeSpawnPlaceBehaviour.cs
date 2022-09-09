using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DurianTreeSpawnPlaceBehaviour : MonoBehaviour
{
    //[Header("Spawn Chance")]
    //[Range(0.0f, 100.0f)] public float spawnChance;
    //[SerializeField] private float spawnValue;

    [Header("Durian")]
    public GameObject theDurianTree;
    public DurianTreePool durianTreePool;

    //public float minTimeAppear, maxTimeAppear;
    //float timeAppear, timer;
    // Start is called before the first frame update
    void Start()
    {
        if (durianTreePool == null)
        {
            durianTreePool = GameObject.FindObjectOfType<DurianTreePool>();
        }
        //timeAppear = Random.Range(minTimeAppear, maxTimeAppear);

        SpawnDurianTreeNow();
    }

    // Update is called once per frame
    /*void Update()
    {
        if (transform.childCount == 0)
        {
            timer += Time.deltaTime;
            if (timer > timeAppear)
            {
                SpawnEnemyNow();

            }

        }

    }*/

    void SpawnDurianTreeNow()
    {
        //spawnValue = Random.Range(0.0f, 100.0f);
        //if (spawnValue < spawnChance)
        //{
            theDurianTree = durianTreePool.GetDurianTrees();
            theDurianTree.transform.SetParent(transform, false);

        //    timer = 0f;
        //    timeAppear = Random.Range(minTimeAppear, maxTimeAppear);
        //}
    }
}
