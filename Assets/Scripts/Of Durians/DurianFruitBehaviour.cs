using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Pool;
public class DurianFruitBehaviour : MonoBehaviour
{
    public float powerAmount;
    public GameObject durianPoolGameObject;
    public DurianFruitPool durianFruitPool;
    public float minFallTime, maxFallTime, minLifeSpan, maxLifeSpan;
    public GameObject freeDurians;
    float timer, fallTime, lifeSpan;
    public Rigidbody durianRb;
    public bool pickable;
    public bool fallen;
    

    // Start is called before the first frame update
    void Start()
    {
        durianFruitPool = GameObject.FindGameObjectWithTag("Durian Pool").GetComponent<DurianFruitPool>();
        timer = 0.0f;
        freeDurians = GameObject.FindWithTag("Durian Parent");
        
        durianRb = GetComponent<Rigidbody>();
        if(gameObject.transform.parent != null)
        {
            if (gameObject.transform.parent.CompareTag("On Tree"))
            {
                OnTree();
            }
            else
            {
                FreeDurians();
            }
        }
        else
        {
            FreeDurians();
        }
    }

    
    void OnTree()
    {
        fallTime = Random.Range(minFallTime, maxFallTime);
        lifeSpan = Random.Range(minLifeSpan, maxLifeSpan);
        if (durianRb != null)
        {
            durianRb.useGravity = false;
        }
        pickable = false;
        fallen = false;
    }

    void FreeDurians()
    {
        pickable = true;
        fallen = true;
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
        if(timer > fallTime)
        {
            Falling();
        }
        
        if(timer > lifeSpan)
        {
            timer = 0.0f;
            OnDisable();
        }
    }

    public void Falling()
    {
        durianRb.useGravity = true;
        pickable = true;
        fallen = true;
        gameObject.transform.SetParent(freeDurians.transform, true);
        timer = 0f;
    }

    public void OnDisable()
    {
        if (gameObject != null)
            { gameObject.SetActive(false); }
        
    }
}
