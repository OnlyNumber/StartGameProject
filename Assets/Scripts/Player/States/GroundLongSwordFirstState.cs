using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundLongSwordFirstState : PlayerBaseState
{
    public override void OnEnter(StateManager _stateManager)
    {
        base.OnEnter(_stateManager);

        attackIndex = 1;
        duration = 0.6f;
        animator.SetTrigger("Attack" + attackIndex);

    }

    public override void OnUpdate()
    {
        base.OnUpdate();
        if(fixedTime >= duration)
        {
            
            if (shouldCombo)
            {
                GetStateManager().SetNextState(new GroundLongSwordSecondState());
            }
            else
            {
                GetStateManager().SetNextStateToMain();
            }
        }
    }

    

}
