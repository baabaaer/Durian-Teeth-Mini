using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundDurianTreeSpawn : MonoBehaviour
{
    private Vector3[] durianTreeSpawnPositions;
    public GameObject[] durianTreeSpawnPlaces;
    public GameObject durianTreeSpawnPlace;
    public GameObject durianTree;
    public int minSpawnPointsAmount, maxSpawnPointsAmount;
    [SerializeField] private int spawnPointsAmount;

    [Header("Limits of Durian Tree Spawn Points")]

    public float x1;
    public float x2, x3, x4;
    public float y1, y2;
    public float z1, z2, z3, z4;

    //public float x1Permitted, x2Permitted, z1Permitted, z2Permitted;

    [SerializeField] private float x, y, z;

    public DurianTreePool durianTreePool;


    // Start is called before the first frame update
    void Start()
    {
        //x1Permitted = x1 - x2;
        //x2Permitted = x4 - x3;
        //z1Permitted = z1 - z2;
        //z2Permitted = z4 - z3;
        //Get Durian Tree Pool
        if (durianTreePool == null)
        {
            durianTreePool = GameObject.FindGameObjectWithTag("Durian Tree Pool").GetComponent<DurianTreePool>();
        }
        //Generate random spawn points
        spawnPointsAmount = Random.Range(minSpawnPointsAmount, maxSpawnPointsAmount);
        durianTreeSpawnPositions = new Vector3[spawnPointsAmount];
        durianTreeSpawnPlaces = new GameObject[spawnPointsAmount];
        for (int i = 0; i < spawnPointsAmount; i++)
        {
            /*int choice = Random.Range(0, 3);

            switch (choice)
            {
                case 0:
                    x = Random.Range(x1, x2);
                    z = Random.Range(z1, z2);
                    break;
                case 1:
                    x = Random.Range(x1, x2);
                    z = Random.Range(z3, z4);
                    break;
                case 2:
                    x = Random.Range(x3, x4);
                    z = Random.Range(z1, z2);
                    break;
                case 3:
                    x = Random.Range(x3, x4);
                    z = Random.Range(z3, z4);
                    break;
                default: break;
            }*/

            x = Random.Range(x1, x4);
            z = Random.Range(z1, z4);

            y = Random.Range(y1, y2);

            durianTreeSpawnPositions[i] = new Vector3(x, y, z);
        }
        for (int i = 0; i < spawnPointsAmount; i++)
        {
            durianTreeSpawnPlaces[i] = Instantiate(durianTreeSpawnPlace, durianTreeSpawnPositions[i], Quaternion.identity);
        }
        /*for (int i = 0; i < spawnPointsAmount; i++)
        {
            GameObject theDurianTree = durianTreePool.GetDurianTrees();
            theDurianTree.transform.SetParent(durianTreeSpawnPlaces[i].transform, false);
        }
        */
    }
}
