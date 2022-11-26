using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IntermidiateAnimation : MonoBehaviour
{
    private PlayerCombat playerCombat;
    void Start()
    {
        playerCombat = GetComponentInParent<PlayerCombat>();
    }

    public void Attack()
    {
        playerCombat.Attack();
    }
    
}
