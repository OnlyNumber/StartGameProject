using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCombat : MonoBehaviour
{
    [SerializeField] private float damage;
    [SerializeField] private float attackRadius;
    [SerializeField] private Transform hitPoint;
    [SerializeField] private LayerMask attackLayerMask;
    private float currentHealth;
    [SerializeField] private float maxHealth;
    private bool isGame = true;

    private void Awake()
    {
        currentHealth = maxHealth;
    }


    private void Update()
    {
      if(currentHealth <= 0)
        {
            Death();
        }
    }

    public void TakeDamage(float takenDamage)
    {
        currentHealth -= takenDamage;
    }

    public void ChangeStats()
    {

    }

    private void Death()
    {
        isGame = false;
        Destroy(gameObject);
    }

    public void Attack()
    {
        Collider2D[] _hits = Physics2D.OverlapCircleAll(hitPoint.position,
            attackRadius, attackLayerMask);

        foreach (Collider2D hit in _hits)
        {
            if(hit.gameObject.CompareTag("Enemy"))
            {
                hit.gameObject.GetComponent<EnemyCombat>().TakeDamage(damage);
            }
        }

    }

    public float GetCurrentHealth()
    {
        return currentHealth;
    }

    public float GetMaxHealth()
    {
        return maxHealth;
    }

    public bool GetIsGame()
    {
        return isGame;
    }


}
