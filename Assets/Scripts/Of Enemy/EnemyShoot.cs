using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyShoot : MonoBehaviour
{
    public EnemyBehaviour enemyBehaviour;
    public DurianFruitPool durianPool;
    public Transform player;
    public GameObject durianFruit;
    public GameObject durianShoot;
    public Transform yeeterOfDurian;
    public DurianFruitBehaviour durianBehave;
    public Rigidbody durianRb;
    public float inAccuracy;
    public Vector3 directionExact, directionWithMargin;
    public float throwingPowerForward, throwingPowerUp;
    // Start is called before the first frame update
    void Awake()
    {
        if(enemyBehaviour == null)
        {
            enemyBehaviour = GetComponent<EnemyBehaviour>();
        }
    }
    private void Start()
    {
        durianPool = GameObject.FindGameObjectWithTag("Durian Pool").GetComponent<DurianFruitPool>();
    }

    // Update is called once per frame
    void Update()
    {
        // you already have player.position
        player = enemyBehaviour.player;
        

    }

    public void Shooting()
    {
        // Shooting at player somewhat inaccurately
        directionExact = player.transform.position - yeeterOfDurian.transform.position;
        float xMargin = Random.Range(-inAccuracy, inAccuracy);
        float yMargin = Random.Range(-inAccuracy, inAccuracy);
        directionWithMargin = directionExact + new Vector3(xMargin, yMargin, 0);

        //durianShoot = Instantiate(durianFruit, yeeterOfDurian.position, yeeterOfDurian.rotation, null);
        durianShoot = durianPool.GetDurians();
        if (durianShoot.activeSelf == false)
        {
            durianShoot.SetActive(true);
        }
        durianShoot.transform.position = yeeterOfDurian.transform.position;
        durianShoot.transform.forward = directionWithMargin.normalized;
        durianShoot.transform.up = directionWithMargin.normalized;
        durianRb = durianShoot.GetComponent<Rigidbody>();
        durianBehave = durianShoot.GetComponent<DurianFruitBehaviour>();
        durianBehave.fallen = true;
        durianBehave.pickable = true;
        durianBehave.gameObject.transform.SetParent(null, false);
       

        durianRb.AddForce(directionWithMargin.normalized * throwingPowerForward, ForceMode.Impulse);
        durianRb.AddForce(directionWithMargin.normalized * throwingPowerUp, ForceMode.Impulse);
    }
}
