using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DurianTreeFruitSpawn : MonoBehaviour
{
    private Vector3[] spawnPositions;
    public GameObject[] spawnPlaces;
    public GameObject spawnPlace;
    public GameObject durianFruit;
    public int minSpawnPointsAmount, maxSpawnPointsAmount;
    [SerializeField] private int spawnPointsAmount;

    [Header("Limits of Durian Spawn Points")]

    public float x1;
    public float x2;
    public float y1;
    public float y2;
    public float z1;
    public float z2;

    [SerializeField] private float x,y,z;

    public DurianFruitPool durianPool;

    
    // Start is called before the first frame update
    void Start()
    {
        //Get Durian Pool
        if(durianPool == null)
        {
            durianPool = GameObject.FindGameObjectWithTag("Durian Pool").GetComponent<DurianFruitPool>();
        }
        //Generate random spawn points
        spawnPointsAmount = Random.Range(minSpawnPointsAmount, maxSpawnPointsAmount);
        spawnPositions = new Vector3[spawnPointsAmount];
        spawnPlaces = new GameObject[spawnPointsAmount];
        for(int i = 0; i < spawnPointsAmount; i++)
        {
            x = Random.Range(x1,x2);
            y = Random.Range(y1,y2);
            z = Random.Range(z1,z2);
            spawnPositions[i] = new Vector3(x,y,z);
        }
        for(int i = 0; i < spawnPointsAmount; i++)
        {
            spawnPlaces[i] = Instantiate(spawnPlace,spawnPositions[i],Quaternion.identity);
        }
        for (int i = 0; i < spawnPointsAmount; i++)
        {
            GameObject theDurianFruit = durianPool.GetDurians();
            theDurianFruit.transform.SetParent(spawnPlaces[i].transform,false);
        }
    }

}
