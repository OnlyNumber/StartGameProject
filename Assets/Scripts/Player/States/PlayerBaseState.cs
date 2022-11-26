using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBaseState : State
{
    public float duration;

    protected Animator animator;

    protected bool shouldCombo;

    protected int attackIndex;
    
    public override void OnEnter(StateManager _stateManager)
    {
        base.OnEnter(_stateManager);
        //moveController = GameObject.Find("Player").GetComponent<MoveController>();
        animator = GameObject.Find("Player").GetComponentInChildren<Animator>();
        _stateManager.GetMoveController().SetIsCanMove(false);
        _stateManager.GetMoveController().GetPlayerRb().velocity = new Vector2(0, 0);
    }

    public override void OnUpdate()
    {
        base.OnUpdate();


        if(Input.GetMouseButtonDown(0) && fixedTime > 0.1f)
        {
            shouldCombo = true;
        }
    }

    public override void OnExit()
    {
        base.OnExit();
        GetStateManager().GetMoveController().SetIsCanMove(true);

    }

    

}
