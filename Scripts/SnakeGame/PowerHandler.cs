using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerHandler : MonoBehaviour
{
    public int points = 5;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.transform.tag == "Player")
        {
            collision.transform.GetComponent<TailHandler>().Eating(points);
            Destroy(gameObject);
        }
    }
}
