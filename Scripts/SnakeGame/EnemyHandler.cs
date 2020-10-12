using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHandler : MonoBehaviour
{
    public Color color;
    int timer = 10;

    Color _color_ = Color.white;

   void Awake()
    {
        FirstLast(timer);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.transform.tag == "Player")
        {
            collision.gameObject.SetActive(false);
            Destroy(gameObject);
        }
    }
    public void FirstLast(int timer)
    {
        GetComponent<BoxCollider2D>().enabled = false;
        GetComponent<SpriteRenderer>().color = color;
        Invoke("Reset", timer);
    }

    public void Reset()
    {
        GetComponent<BoxCollider2D>().enabled = true;
        GetComponent<SpriteRenderer>().color = _color_;
    }
}
