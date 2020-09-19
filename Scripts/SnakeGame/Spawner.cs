using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
  public Vector2 outbounds_topcorner, outbounds_bottomcorner;
    public GameObject powerup;

    public void FixedUpdate()
    {
        if (transform.childCount <= 0)
        {
            GameObject pup = Instantiate(powerup);
            pup.transform.position = new Vector3(Mathf.FloorToInt(Random.Range(outbounds_topcorner.x, outbounds_bottomcorner.x)),
                            Mathf.FloorToInt(Random.Range(outbounds_topcorner.y, outbounds_bottomcorner.y)), 0f);
            pup.transform.SetParent(transform);
        }

    }

}
