using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float moveSpeed = 5f;
    public Rigidbody2D rb;
    public TailHandler tail;

   public Vector2 movement, movementOld;
   bool gotInput = false;

    void Update()
    {
        CheckDirection();
    }

    private void CheckDirection()
    {
        Vector2 move = movement;
        tail.UpdatePositions(transform.position);
        movement.x = Input.GetAxisRaw("Horizontal");
        movement.y = Input.GetAxisRaw("Vertical");
        if (move != movement)
        {
            gotInput = true;
            if (move != Vector2.zero)
            {
                movementOld = move;
            }
            else
            {
                movementOld = movement;
            }
        }
        else gotInput = false;
        if ((movementOld.x ==1 || movementOld.x == -1) && movementOld.y !=0) movementOld.x = 0;

        InputTimer(1f);
    }

    private void InputTimer(float time)
    {
        float timer = Time.fixedDeltaTime;
        while (timer > time)
        {
            gotInput = false;
        }
    }

    void FixedUpdate()
    {
        InvokeRepeating("Move", 1, 1);

    }


    public void Move()
    {

        if (gotInput == false)
        {     
            rb.MovePosition(rb.position + movementOld * (moveSpeed * Time.fixedDeltaTime));
        }else
            rb.MovePosition(rb.position + movement * (moveSpeed * Time.fixedDeltaTime));


    }
}
