using UnityEngine;

public abstract class State
{
    private StateManager stateManager;
    protected float time { get; set; }
    protected float fixedTime { get; set; }
    protected float lateTime { get; set; }


    public virtual void OnUpdate()
    {

    }

    public virtual void OnFixedUpdate()
    {
        fixedTime += Time.deltaTime;
    }


    public virtual void OnEnter(StateManager _stateManager)
    {
        stateManager = _stateManager;
    }

    public virtual void OnExit()
    {

    }

    public StateManager GetStateManager()
    {
        return stateManager;
    }
}

