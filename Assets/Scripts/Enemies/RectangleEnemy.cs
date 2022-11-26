using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RectangleEnemy : EnemyCombat
{
    public LineRenderer m_lineRender;
    [SerializeField] private float laserDistance;
    private bool canRotating;
    void Start()
    {
        base.OnStart();
        canRotating = true;
        TimeBetweenAttack = AttackRate;
    }

    void Update()
    {
        base.OnUpdate();

        if (canRotating)
        {
            LookAtPlayer();
        }

        if (TimeBetweenAttack <= 0)
        {
            StartCoroutine(StartShooting());
            TimeBetweenAttack = AttackRate;
        }

    }

    private void LookAtPlayer()
    {
        Vector3 difference;
        float rotZ;

        difference = Player.transform.position - transform.position;
        rotZ = Mathf.Atan2(difference.y, difference.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(0f, 0f, rotZ + 180f);
    }

    private void Shoot()
    {
        Debug.Log("Shoot Was");

        RaycastHit2D ray = Physics2D.Raycast(transform.position, -transform.right, laserDistance, AttackLayerMask);

        if (ray)
        {
            Draw2DRay(transform.position, ray.point);
            if (ray.transform.gameObject.CompareTag("Player"))
            {
                ray.collider.gameObject.GetComponent<PlayerCombat>().TakeDamage(Damage);

            }
        }
        else
        {
            Draw2DRay(transform.position, -transform.right * laserDistance);
        }
    }

    private void Draw2DRay(Vector2 startPos, Vector2 endPos)
    {
        m_lineRender.SetPosition(0, startPos);
        m_lineRender.SetPosition(1, endPos);
    }
    IEnumerator StartShooting()
    {
        canRotating = false;
        EnemyAnimator.SetTrigger("LaserShoot");
        yield return new WaitForSeconds(1.5f);
        m_lineRender.enabled = true;
        Shoot();
        canRotating = true;
        yield return new WaitForSeconds(0.5f);
        StartCoroutine(DestroyingBeam());
    }

    IEnumerator DestroyingBeam()
    {
        
        yield return new WaitForSeconds(0.5f);
        m_lineRender.enabled = false;
    }

}
