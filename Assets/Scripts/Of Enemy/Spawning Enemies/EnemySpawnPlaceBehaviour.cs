using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawnPlaceBehaviour : MonoBehaviour
{

    [Header("Spawn Chance")]
    [Range(0.0f, 100.0f)] public float spawnChance;
    [SerializeField] private float spawnValue;

    [Header("Durian")]
    public GameObject theEnemy;
    public EnemyPool enemyPool;

    public float minTimeAppear, maxTimeAppear;
    float timeAppear, timer;
    // Start is called before the first frame update
    void Start()
    {
        if (enemyPool == null)
        {
            enemyPool = GameObject.FindObjectOfType<EnemyPool>();
        }
        timeAppear = Random.Range(minTimeAppear, maxTimeAppear);
    }

    // Update is called once per frame
    void Update()
    {
        if (transform.childCount == 0)
        {
            timer += Time.deltaTime;
            if (timer > timeAppear)
            {
                SpawnEnemyNow();

            }

        }

    }

    void SpawnEnemyNow()
    {
        spawnValue = Random.Range(0.0f, 100.0f);
        if (spawnValue < spawnChance)
        {
            theEnemy = enemyPool.GetEnemies();
            theEnemy.transform.SetParent(transform, false);

            timer = 0f;
            timeAppear = Random.Range(minTimeAppear, maxTimeAppear);
        }
    }
}
