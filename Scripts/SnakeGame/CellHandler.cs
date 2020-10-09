using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CellHandler : MonoBehaviour
{
    public float ttl = 0;
    public int childindex = 0;
    public int cellcount;

    void Start()
    {
        ttl = Mathf.CeilToInt(Random.Range(0000000f, 9999999f));
    }
    void Update()
    {
        childindex = transform.GetSiblingIndex();
        //FirstLast();
    }
    private IEnumerator Countdown()
    {
        while (ttl > 0)
        {
            ttl--;
            yield return new WaitForSeconds(1f);
        }
        Destroy(gameObject);
    }

    public void FirstLast()
    {
        int parentchilds = cellcount;
        if(childindex == parentchilds)
        {
            ttl = 0;
        }else if(childindex > parentchilds)
        {
            ttl = 20;
        }

    }

}
