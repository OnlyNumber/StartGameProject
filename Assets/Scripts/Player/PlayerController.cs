using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    
    private MoveController moveController;
    private float horizontalInput;
    private bool isJump;
    private bool isDash;

    void Start()
    {
        moveController = GetComponent<MoveController>();
    }

    void Update()
    {
        moveController.Move(horizontalInput, isJump, isDash);
        isJump = false;
        isDash = false;
       
    }


    public void MoveRight()
    {
        horizontalInput = 1;
    }
    public void MoveLeft()
    {
        horizontalInput = -1;
    }

    public void NotMoving()
    {
        horizontalInput = 0;
    }


    public void Jump()
    {
        isJump = true;
    }

    public void Dash()
    {
        isDash = true;
    }

    public float GetHorizontalInput()
    {
        return horizontalInput;
    }


}
