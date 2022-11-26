using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlyingState : State
{
    private Animator bootsAnimator;
    

    public override void OnEnter(StateManager _stateManager)
    {


        base.OnEnter(_stateManager);

        bootsAnimator = GameObject.Find("BootsGO").GetComponent<Animator>();
        bootsAnimator.SetTrigger("StartFlyingTrigger");

    }

    public override void OnUpdate()
    {
        base.OnUpdate();
        if(GetStateManager().GetMoveController().GetIsGround())
        {
            GetStateManager().SetNextStateToMain();
        }


    }


    public override void OnExit()
    {
        base.OnExit();
        bootsAnimator.SetTrigger("FinishFlyingTrigger");
    }
}
