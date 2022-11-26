using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DashState : State
{
    public float duration;

    protected Animator animator;
    protected Animator animBoots;

    public override void OnEnter(StateManager _stateManager)
    {
        base.OnEnter(_stateManager);

        GameObject.Find("Player").tag = "Untagged";

        animator = GameObject.Find("Player").GetComponentInChildren<Animator>();
        animBoots = GameObject.Find("BootsGO").GetComponent<Animator>();
        duration = 0.9f;

        

        animator.SetTrigger("DashTrigger");
        animBoots.SetTrigger("DashTrigger");

    }

    public override void OnUpdate()
    {
        base.OnUpdate();

        if (fixedTime >= duration)
        {
            GetStateManager().SetNextStateToMain();
        }
    }

    public override void OnExit()
    {
        base.OnExit();
        GameObject.Find("Player").tag = "Player";

    }

}
