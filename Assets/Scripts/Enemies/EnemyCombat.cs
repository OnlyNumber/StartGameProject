using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class EnemyCombat : MonoBehaviour
{
    private Animator enemyAnimator;
    private GameObject player;
    [SerializeField] private LayerMask attackLayerMask;
    [SerializeField] private float maxHealth;
    [SerializeField] private float currentHealth;
    [SerializeField] private float damage;
    [SerializeField] private float attackRate;
    [SerializeField] private float speed;

    private UserInterface userInterface;
    private float timeBetweenAttack;
    private bool isFlippedX;
    private Rigidbody2D enemyRb;

    public float AttackRate
    {
        get
        {
            return attackRate;
        }
    }

    public GameObject Player
    {
        get
        {
            return player;
        }
    }

    public Animator EnemyAnimator
    {
        get
        {
            return enemyAnimator;
        }
    }

    public float Speed
    {
        get
        {
            return speed;
        }
        set
        {
            speed = value;
        }
    }

    public float TimeBetweenAttack
    {
        get
        {
            return timeBetweenAttack;
        }
        set
        {
            timeBetweenAttack = value;
        }

    }

    public LayerMask AttackLayerMask
    {
        get
        {
            return attackLayerMask;
        }
    }

    public float Damage
    {
        get
        {
            return damage;
        }
    }

    public float CurrentHealth
    {
        get
        {
            return currentHealth;
        }
    }



    public virtual void OnStart()
    {
        userInterface = GameObject.Find("UI").GetComponent<UserInterface>();
        player = GameObject.Find("Player");
        currentHealth = maxHealth;
        enemyRb = GetComponent<Rigidbody2D>();
        enemyAnimator = GetComponentInChildren<Animator>();
    }

    public virtual void OnUpdate()
    {

        if (CurrentHealth <= 0)
        {
            userInterface.SetScore();
            Destroy(gameObject);
        }

        timeBetweenAttack -= Time.deltaTime;

        if ((player.transform.position.x - transform.position.x) < 0 && !isFlippedX)
        {
            Flip();
        }
        if ((player.transform.position.x - transform.position.x) > 0 && isFlippedX)
        {
            Flip();
        }


    }


    public virtual void TakeDamage(float takenDamage)
    {
        currentHealth -= takenDamage;
        Debug.Log("Current Health: " + currentHealth);
    }

    private void Flip()
    {
        isFlippedX = !isFlippedX;
        Vector3 localScale = enemyRb.transform.localScale;
        localScale.x *= -1;
        enemyRb.transform.localScale = localScale;

        return;
    }

    public virtual void Attack()
    {
    }


}
