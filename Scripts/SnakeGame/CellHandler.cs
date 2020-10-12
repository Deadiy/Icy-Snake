using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CellHandler : MonoBehaviour
{
    public float ttl = 0;
    public int childindex = 0;
    public int cellcount;
    private Color _color_ = Color.white;
    public GameObject parent;
    void Start()
    {
        ttl = Mathf.CeilToInt(Random.Range(0000000f, 9999999f));

        transform.SetParent(parent.transform);
    }
    void Update()
    {
        childindex = transform.GetSiblingIndex();
    }

    public void FirstLast(Color color)
    {
        GetComponent<SpriteRenderer>().color = color;
        Invoke("ColorReset",0.178f);
    }

    public void ColorReset()
    {
        GetComponent<SpriteRenderer>().color = _color_;
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {

        if (collision.tag == "Player" && childindex >= 2)
        {
            parent.SetActive(false);
            collision.gameObject.SetActive(false);

        }
        if(collision.tag == "Powerup")
        {
            Destroy(collision.gameObject);
        }
    }
}
