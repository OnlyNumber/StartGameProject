using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeleeEntryState : State
{
    public override void OnEnter(StateManager _stateManager)
    {
        base.OnEnter(_stateManager);

        State nextState = (State)new GroundLongSwordFirstState();
        _stateManager.SetNextState(nextState);

    }
}
