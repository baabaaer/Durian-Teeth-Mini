using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DurianTreeHealth : MonoBehaviour
{
    public float treeHealth;
    public float totalTreeHealth;
    float healthReduction;

    // Start is called before the first frame update
    void Start()
    {
        treeHealth = totalTreeHealth;
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.collider.tag == "Durian")
        {
            healthReduction = collision.collider.GetComponent<DurianFruitBehaviour>().powerAmount;
        }
        treeHealth -= healthReduction;
    }

    // Update is called once per frame
    void Update()
    {
        if(treeHealth < 0)
        {
            Destroy(gameObject);
            SceneManager.LoadScene("LoseScene");
        }
    }
}
