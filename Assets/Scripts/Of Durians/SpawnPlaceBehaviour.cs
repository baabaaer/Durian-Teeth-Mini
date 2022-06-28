using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnPlaceBehaviour : MonoBehaviour
{
    [Header("Spawn Chance")]
    [Range(0.0f, 100.0f)] public float spawnChance;
    [SerializeField] private float spawnValue;

    [Header("Durian")]
    public GameObject theDurianFruit;
    public DurianFruitPool durianFruitPool;

    public float minTimeDrop, maxTimeDrop;
    float timeDrop, timer;
    // Start is called before the first frame update
    void Start()
    {
        if( durianFruitPool == null)
        {
            durianFruitPool = GameObject.FindObjectOfType<DurianFruitPool>();
        }
        timeDrop = Random.Range(minTimeDrop, maxTimeDrop);
    }

    // Update is called once per frame
    void Update()
    {
        if(transform.childCount == 0)
        {
            timer += Time.deltaTime;
            if (timer > timeDrop)
            {
                SpawnDurianNow();
                
            }
            
        }

    }

    void SpawnDurianNow()
    {
        spawnValue = Random.Range(0.0f, 100.0f);
        if (spawnValue < spawnChance)
        {
            theDurianFruit = durianFruitPool.GetDurians();
            theDurianFruit.transform.SetParent(transform, false);
            
            timer = 0f;
            timeDrop = Random.Range(minTimeDrop, maxTimeDrop);
        }        
    }
}
