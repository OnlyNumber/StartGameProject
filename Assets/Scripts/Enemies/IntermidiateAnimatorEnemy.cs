using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IntermidiateAnimatorEnemy : MonoBehaviour
{
    private EnemyCombat enemyCombat;
    void Start()
    {
        enemyCombat = GetComponentInParent<EnemyCombat>();
    }

    // Update is called once per frame
    public void Attack()
    {
        enemyCombat.Attack();
    }

    public void SetSpeedEnemy(float speed)
    {
        enemyCombat.Speed = speed;
    }


}
