using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cellkiller : MonoBehaviour
{
    public int ttl = 1;

    void Start()
    {
        InvokeRepeating("DestroyCells", 0, 0.5f);
    }
}