using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ComboController : MonoBehaviour
{

    [SerializeField] public Collider2D hitbox;
    [SerializeField] public GameObject hitEffect;

    private StateManager meleeStateManager;
    private Animator anim;
    private PlayerController playerController;
    [SerializeField] private Animator animBoots;
    private void Start()
    {
        meleeStateManager = GetComponent<StateManager>();
        anim = GameObject.Find("Player").GetComponentInChildren<Animator>();
        playerController = gameObject.GetComponent<PlayerController>();
        
    }

    private void Update()
    {
        if (meleeStateManager.CurrentState.GetType() == typeof(IdleState))
        {
            anim.SetFloat("MoveInput", Mathf.Abs(playerController.GetHorizontalInput()));
            animBoots.SetFloat("MoveInput", Mathf.Abs(playerController.GetHorizontalInput()));
        }
    }

    public void Attack()
    {
        if (meleeStateManager.CurrentState.GetType() == typeof(IdleState))
        {
            meleeStateManager.SetNextState(new GroundLongSwordFirstState());
        }

        if (meleeStateManager.CurrentState.GetType() == typeof(FlyingState))
        {
            meleeStateManager.SetNextState(new FlyingAttackState());
        }
    }

    public void Dash()
    {
        meleeStateManager.SetNextState(new DashState());
    }


}
