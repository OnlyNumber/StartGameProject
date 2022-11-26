using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundLongSwordSecondState : PlayerBaseState
{
    public override void OnEnter(StateManager _stateManager)
    {
        base.OnEnter(_stateManager);



        attackIndex = 2;
        duration = 0.3f;
        animator.SetTrigger("Attack" + attackIndex);
    }

    public override void OnUpdate()
    {
        base.OnUpdate();

        if(fixedTime >= duration)
        {
            GetStateManager().SetNextStateToMain();
        }
    }

    

}
