using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlyingAttackState : PlayerBaseState
{
    
    public override void OnEnter(StateManager _stateManager)
    {
        base.OnEnter(_stateManager);

        attackIndex = 3;
        duration = 0.5f;
        animator.SetTrigger("Attack" + attackIndex);
    }

    public override void OnUpdate()
    {
        base.OnUpdate();

        if (fixedTime >= duration)
        {
            GetStateManager().SetNextState(new FlyingState());
        }
    }
}
