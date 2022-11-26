using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveController : MonoBehaviour
{
    [SerializeField] private Transform groundPoint;
    [SerializeField] private Rigidbody2D playerRb;
    [SerializeField] private float speed;
    [SerializeField] private float jumpPower;
    [SerializeField] private float radius;
    [SerializeField] private bool isFlippedX;

    private StateManager meleeStateManager;
    private float jumpCooldown;
    private bool isDashing = false;
    private bool isCanMove = true;

    [Range(0, .3f)] [SerializeField] private float m_MovementSmoothing = .05f;

    private bool isGround;
    private Vector3 m_Velocity = Vector3.zero;


    private void Awake()
    {
        playerRb = GetComponent<Rigidbody2D>();
        meleeStateManager = GetComponent<StateManager>();
    }

    private void Update()
    {
        CheckGround();
        if(isGround == false && meleeStateManager.CurrentState.GetType() != typeof(FlyingState)
            && meleeStateManager.CurrentState.GetType() != typeof(FlyingAttackState) && !isDashing)
        {
            meleeStateManager.SetNextState(new FlyingState());
        }
    }


    public void Move(float horizontalinput, bool jump, bool dash)
    {
        if (!isDashing && isCanMove)
        {
            Vector3 targetVelocity = new Vector2(horizontalinput * speed, playerRb.velocity.y);

            playerRb.velocity = Vector3.SmoothDamp(playerRb.velocity, targetVelocity,
                ref m_Velocity, m_MovementSmoothing);



            if (jump && isGround && jumpCooldown < Time.time && isCanMove)
            {
                playerRb.AddForce(new Vector2(0, jumpPower * Time.fixedDeltaTime),
                    ForceMode2D.Impulse);
                jumpCooldown = Time.time + 0.2f;
            }
        }
        if (!isDashing)
        {
            if (dash)
            {
                StartCoroutine(Dash());
            }

            if (horizontalinput > 0 && isFlippedX == true)
            {
                Flip();
            }
            else if (horizontalinput < 0 && isFlippedX == false)
            {
                Flip();
            }
        }
    }

    private void CheckGround()
    {
        Collider2D[] ground = Physics2D.OverlapCircleAll(groundPoint.position, radius);

        foreach (Collider2D groundObject in ground)
        {
            if (groundObject.CompareTag("Ground"))
            {
                isGround = true;
                return;
            }
        }
        isGround = false;
    }

    private IEnumerator Dash()
    {
        float direction;
        
        if(isFlippedX)
        {
            direction = -1;
        }
        else
        {
            direction = 1;
        }
        playerRb.velocity = new Vector2(0,0);
        
        isDashing = true;
        playerRb.velocity = new Vector2(playerRb.velocity.x, 0);
        playerRb.AddForce(new Vector2(15f * direction, 0f), ForceMode2D.Impulse);
        float gravite = playerRb.gravityScale;
        playerRb.gravityScale = 0;
        yield return new WaitForSeconds(0.4f);
        isDashing = false;
        playerRb.gravityScale = gravite;
    }

    private void Flip()
    {
        isFlippedX = !isFlippedX;
        Vector3 localScale = playerRb.transform.localScale;
        localScale.x *= -1;
        playerRb.transform.localScale = localScale;

        return;
    }

    public void SetIsCanMove(bool isMove)
    {
        isCanMove = isMove;
        return;
    }

    public Rigidbody2D GetPlayerRb()
    {
        return playerRb;
    }

    public bool GetIsGround()
    {
        return isGround;
    }


}
