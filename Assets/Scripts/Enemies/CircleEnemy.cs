using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CircleEnemy : EnemyCombat
{
    [SerializeField]private Transform hitPoint;
    

    void Start()
    {
        base.OnStart();
    }

    private void Update()
    {
        base.OnUpdate();

        if (Vector2.Distance(transform.position, Player.transform.position) < 2)
        {
            if (TimeBetweenAttack <= 0)
            {
                EnemyAnimator.SetTrigger("AttackTrigger");
                TimeBetweenAttack = AttackRate;
            }
        }
        else
        {
            transform.position = Vector2.MoveTowards(transform.position,
                Player.transform.position, Speed * Time.deltaTime);
        }


    }

    public override void Attack()
    {
        Collider2D[] _hit = Physics2D.OverlapCircleAll(hitPoint.position, 1,
            AttackLayerMask);

        foreach (Collider2D hit in _hit)
        {
            if(hit.gameObject.CompareTag("Player"))
            {
                hit.gameObject.GetComponent<PlayerCombat>().TakeDamage(Damage);
            }
        }

    }



}
