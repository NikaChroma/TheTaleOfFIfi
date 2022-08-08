using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class FoxHealthScript : MonoBehaviour
{
    [SerializeField] private float maxHealth;
    [SerializeField] private Animator foxAnim;
    [SerializeField] private Image HealthBar;

    private float currentHealth;
    private Rigidbody2D rb;

    private void Start()
    {
        Death.SetActive(false);
        rb = GetComponent<Rigidbody2D>();
        currentHealth = maxHealth;
        timeToDamage = true;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Water"))
        {
            foxAnim.SetTrigger("Fear");
            rb.velocity = new Vector2(5, 5);
        }
        if (collision.CompareTag("Hedgehog"))
        {
            TakeDamage(25);
        }
    }
    public void TakeDamage(float damage)
    {
        if (timeToDamage)
        {
            foxAnim.SetTrigger("Fear");
            rb.velocity = new Vector2(6, 5);
            currentHealth -= damage;
            UpdateHealth();
            StartCoroutine("NewDamage");

        }
    }
    private void UpdateHealth()
    {
        HealthBar.fillAmount = currentHealth / maxHealth;
        if(currentHealth <= 0)
        {
            Death.SetActive(true);
            StartCoroutine("DeathTime");
        }
    }
    
    private bool timeToDamage;
    IEnumerator NewDamage()
    {
        timeToDamage = false;
        yield return new WaitForSeconds(1);
        timeToDamage = true;
    }
    [SerializeField] private GameObject Death;
    IEnumerator DeathTime()
    {
        yield return new WaitForSeconds(3);
        SceneManager.LoadScene(0);
    }
}
