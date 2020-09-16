using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScreenOverflow : MonoBehaviour
{
    public bool top_right;
    public GameObject Player;
    string type;
 public   Vector2 offset;
    private void Start()
    {
        type = transform.tag;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Overflow();
    }

    void Overflow()
    {
        Vector3 position = Player.transform.position;
        if (top_right == true)
        {
            if (type == "Vertical")
            {
                Player.transform.position = new Vector3(-1*(3 + offset.x), position.y, position.z);
            }
            if (type == "Horizontal")
            {
                Player.transform.position = new Vector3(position.x, -1 * (3 + offset.y), position.z);
            }
        }
        else
        {
            if (type == "Vertical")
            {
                Player.transform.position = new Vector3(3 + offset.x, position.y, position.z);
            }
            if (type == "Horizontal")
            {
                Player.transform.position = new Vector3(position.x, 3 + offset.y, position.z);
            }
        }

    }
}
