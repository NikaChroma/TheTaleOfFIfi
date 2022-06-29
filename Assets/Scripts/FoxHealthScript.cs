using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FoxHealthScript : MonoBehaviour
{
    [SerializeField] private float maxHealth;
    [SerializeField] private float maxLuck;
    [SerializeField] private Animator foxAnim;
    [SerializeField] private Image HealthBar;
    [SerializeField] private Image luckBar;
    private float currentHealth;
    private float currentLuck;
    private Rigidbody2D rb;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        currentHealth = maxHealth;
        currentLuck = 50;
        timeToDamage = true;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Water"))
        {
            foxAnim.SetTrigger("Fear");
            rb.velocity = new Vector2(5, 5);
            AddLuck(-5);
        }
        if (collision.CompareTag("Hedgehog"))
        {
            TakeDamage(5);
        }
    }
    public void TakeDamage(float damage)
    {
        if (timeToDamage)
        {
            foxAnim.SetTrigger("Fear");
            rb.velocity = new Vector2(6, 5);
            if (Random.Range(0, 100) > currentLuck)
            {
                currentHealth -= damage;
            }
            else
            {
                currentLuck -= damage;
            }
            UpdateHealth();
            UpdateLuck();
            StartCoroutine("NewDamage");
        }
    }
    private void UpdateHealth()
    {
        HealthBar.fillAmount = currentHealth / maxHealth;
    }
    public void UpdateLuck()
    {
        luckBar.fillAmount = currentLuck / maxLuck;
    }
    public void AddLuck(float luck)
    {
        if (timeToDamage)
        {
            currentLuck += luck;
            UpdateLuck();
            StartCoroutine("NewDamage");
        }
    }
    private bool timeToDamage;
    IEnumerator NewDamage()
    {
        timeToDamage = false;
        yield return new WaitForSeconds(1);
        timeToDamage = true;
    }
}
