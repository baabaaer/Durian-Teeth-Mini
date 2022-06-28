using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyHealthBar : MonoBehaviour
{
    private Camera cam;
    private float maxHealth, currentHealth;
    public Slider healthBar;
    public EnemyBehaviour enemyBehaviour;

    private void Start()
    {
        cam = Camera.main;
        // We need to make sure this bar only move for its parent!
        enemyBehaviour = GetComponentInParent<EnemyBehaviour>();
    }
    private void Update()
    {
        transform.rotation = Quaternion.LookRotation(transform.position - cam.transform.position);
        maxHealth = enemyBehaviour.totalEnemyHealth;
        currentHealth = enemyBehaviour.enemyHealth;
        UpdateEnemyHealthBar(maxHealth,currentHealth);
    }

    public void UpdateEnemyHealthBar(float maxHealth, float currentHealth)
    {
        float ratio = currentHealth / maxHealth;
        healthBar.value = ratio;
    }

    
}
