using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StateManager : MonoBehaviour
{
    public string customName;

    private State currentState;

    [SerializeField] public State CurrentState { get; private set; }

    private MoveController moveController;

    private State mainStateType;

    public State nextState;

    private void Start()
    {
        moveController = GetComponent<MoveController>();
        OnValidate();
        SetNextStateToMain();
    }


    private void Update()
    {
        if (nextState != null)
        {
            SetState(nextState);
        }

        if (CurrentState != null)
        {
            CurrentState.OnUpdate();
        }

    }

    private void FixedUpdate()
    {
        if (CurrentState != null)
        {
            CurrentState.OnFixedUpdate();
        }
    }


    public void SetNextState(State _newState)
    {
        CurrentState.OnExit();
        CurrentState = _newState;
        CurrentState.OnEnter(this);
    }

    public void SetNextStateToMain()
    {
        nextState = mainStateType;
    }

    private void OnValidate()
    {
        if (mainStateType == null)
        {
            if (customName == "Combat")
            {
                mainStateType = new IdleState();
            }
        }
    }

    private void SetState(State _newState)
    {
        nextState = null;
        if (CurrentState != null)
        {
            CurrentState.OnExit();
        }
        CurrentState = _newState;
        CurrentState.OnEnter(this);
    }

    public MoveController GetMoveController()
    {
        return moveController;
    }

}
