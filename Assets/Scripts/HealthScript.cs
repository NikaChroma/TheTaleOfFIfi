using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthScript : MonoBehaviour
{
    [SerializeField] private float maxHealth;
    private float currentHealth;
    private bool isAlive;

    private void Start()
    {
        currentHealth = maxHealth;
        isAlive = true;
    }

    public void TakeDamage(float damage)
    {
        if (isAlive)
        {
            currentHealth -= damage;
            CheckAlive();
        }
    }

    private void CheckAlive()
    {
        if (currentHealth <= 0) isAlive = false;
    }
}
