using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
  public Vector2 outbounds_topcorner, outbounds_bottomcorner;
    public GameObject player, powerUps , enemies;
    public GameObject[] powerup,enemy;

    private int cellcount;
    private int level_barrier = 10;
    private Vector2 oldpos;
    private GameObject tail;
    private void Start()
    {
        tail = player.GetComponent<PlayerController>().tail.gameObject;
    }

    void FixedUpdate()
    {      
        Regulator();
        if (player.activeSelf == false)
        {
             gameObject.SetActive(false);
        }
        cellcount = tail.GetComponent<TailHandler>().cellcount;
    }
    public void Regulator()
    {

        if (cellcount < level_barrier)
        {
            if (powerUps.transform.childCount <= 0)
                PlaceOnWorld();
        }
        else if(cellcount >= level_barrier)
        {
            if (powerUps.transform.childCount <= 0)
                PlaceOnWorld(true);
        }
    }

    public void PlaceOnWorld(bool spawn_enemy = false)
    {
        GameObject pup = Instantiate(powerup[0]);
        pup.transform.position = NewPlacement();
        pup.transform.SetParent(powerUps.transform);
        if (spawn_enemy)
        {
            GameObject en = Instantiate(enemy[0]);
            en.transform.position = NewPlacement();
            en.transform.SetParent(enemies.transform);
        }
    }
    public Vector2 NewPlacement()
    {
        Vector2 meow = new Vector2(Mathf.FloorToInt(Random.Range(outbounds_topcorner.x, outbounds_bottomcorner.x)),
        Mathf.FloorToInt(Random.Range(outbounds_topcorner.y, outbounds_bottomcorner.y)));

        if (meow != oldpos && tail.GetComponent<TailHandler>().CheckPos(meow)== false )
        {
            oldpos = meow;
            return meow;
        }
        else return NewPlacement();
    }
}
