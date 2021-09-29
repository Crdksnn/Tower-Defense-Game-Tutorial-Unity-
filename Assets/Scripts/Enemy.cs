using UnityEngine;
using UnityEngine.UI;

public class Enemy : MonoBehaviour
{
    public GameObject deathEffectPrefab;

    public float startHealth = 100f;
    public float health;
    public int value = 50;
    public float startSpeed = 10f;
    [HideInInspector]
    public float speed;

    [Header("Unity Stuff")]

    public Image healthBar;

    private bool isDead = false;

    void Start()
    {
        health = startHealth;
        speed = startSpeed;
    }

    public void TakeDamage(float amount)
    {
        health -= amount;

        healthBar.fillAmount = health / startHealth;

        if(health <= 0 && !isDead)
        {
            Die();
        }

    }

    public void Slow(float amount)
    {
        speed = startSpeed * (1f - amount);
    }

    void Die()
    {
        isDead = true;

        GameObject deathEffect = Instantiate(deathEffectPrefab, transform.position, Quaternion.identity);
        Destroy(gameObject);
        Destroy(deathEffect, 3f);
        PlayerStats.money += value;
        EnemySpawner.enemiesAlive--;
    }

}
