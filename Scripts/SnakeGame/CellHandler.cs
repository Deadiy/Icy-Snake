﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CellHandler : MonoBehaviour
{
    public float ttl = 1f;

    void Start()
    {
        StartCoroutine(Countdown());
    }

    private IEnumerator Countdown()
    {
        while (ttl > 0)
        {
            Debug.Log(ttl--);
            yield return new WaitForSeconds(1);
        }
        Destroy(gameObject);
    }
}