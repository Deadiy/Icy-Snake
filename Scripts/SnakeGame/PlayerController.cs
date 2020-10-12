using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;
using UnityEngine.XR;
using Debug = UnityEngine.Debug;

public class PlayerController : MonoBehaviour
{
    public float moveSpeed = 5f;
    public Rigidbody2D rb;
    public TailHandler tail;
    public GameObject head;
    public Vector2 movement, movementOld;
    public int score = 0;

    bool gotInput = false;

    void Update()
    {
        CheckDirection();
        Move();
    }


    private void CheckDirection()
    {
        Vector2 move = movement;
        movement =new Vector2 (Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));
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

     
    }


    public void HeadHandler()
    {
        int dir = 0;
        switch (movementOld.ToString())
        {
            case "(-1.0, 0.0)":
                dir = 0;
                break;
            case "(1.0, 0.0)":
                dir = 180;
                break;
            case "(0.0, 1.0)":
                dir = -90;
                break;
            case "(0.0, -1.0)":
                dir = 90;
                break;
            default:
                break;
        }
        transform.rotation = Quaternion.Euler(Vector3.forward * dir);
    }



    public void Move()
    {

        if (gotInput == false)
        {     
            rb.MovePosition(rb.position + movementOld * (moveSpeed * Time.fixedDeltaTime));

        }
        else
            rb.MovePosition(rb.position + movement * (moveSpeed * Time.fixedDeltaTime));
        HeadHandler();


    }

    public void OnDeath()
    {
        gameObject.SetActive(false);
        tail.GetComponent<TailHandler>().cells.SetActive(false);
    }
}
