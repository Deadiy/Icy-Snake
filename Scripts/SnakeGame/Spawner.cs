using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
  public Vector2 outbounds_topcorner, outbounds_bottomcorner;
    public GameObject player, powerup , enemy;
    public GameObject[] powerups,enemies;

    private int cellcount;
    private int level_barrier = 40;
    private Vector2 oldpos;
    private GameObject tail;
    private void Start()
    {
        tail = player.GetComponent<PlayerController>().tail.gameObject;
    }

    void FixedUpdate()
    {      
        Regulator();
        GameOver();
    }
    public void Regulator()
    {

        if (player.GetComponent<PlayerController>().score < level_barrier)
        {
            if (powerup.transform.childCount <= 0)
                PlaceOnWorld();
        }
        else if(player.GetComponent<PlayerController>().score >= level_barrier)
        {
            if (powerup.transform.childCount <= 0)
                PlaceOnWorld(true);
        }
    }

    public void PlaceOnWorld(bool spawn_enemy = false)
    {
        GameObject pup = Instantiate(RandomObject(powerups));
        pup.transform.position = NewPlacement();
        pup.transform.SetParent(powerup.transform);
        if (spawn_enemy)
        {
            GameObject en = Instantiate(RandomObject(enemies));
            en.transform.position = NewPlacement();
            en.transform.SetParent(enemy.transform);
        }
    }

    public bool CheckPos(Vector3 pos, GameObject[] objects)
    {
        bool check = false;

        for (int i = 0; i < objects.Length; i++)
        {
            if (pos == objects[i].transform.position)
            {
                check = true;
            }
        }
        return check;
    }
    public bool CheckPos(Vector3 pos, GameObject[] objects, GameObject[] objects2)
    {
        bool check = false;

        for (int i = 0; i < objects.Length; i++)
        {
            if (pos == objects[i].transform.position)
            {
                check = true;
            }
        }
        for (int i = 0; i < objects2.Length; i++)
        {
            if (pos == objects2[i].transform.position)
            {
                check = true;
            }
        }
        return check;
    }
    public void GameOver()
    {
        if (player.activeSelf == false)
        {
            gameObject.SetActive(false);
            player.GetComponent<PlayerController>().OnDeath();
        }
    }
    public GameObject RandomObject(GameObject[] inst)
    {
        GameObject obj = inst[0];
        if (inst.Length > 0)
        {
             obj = inst[Random.Range(0, inst.Length)];
        }
        return obj;
    }

    public Vector2 NewPlacement()
    {
        Vector2 meow = new Vector2(Mathf.FloorToInt(Random.Range(outbounds_topcorner.x, outbounds_bottomcorner.x)),
        Mathf.FloorToInt(Random.Range(outbounds_topcorner.y, outbounds_bottomcorner.y)));

        if (meow != oldpos && tail.GetComponent<TailHandler>().CheckPos(meow)== false && CheckPos(meow,enemies, powerups) == false)
        {
            oldpos = meow;
            return meow;
        }
        else return NewPlacement();
    }
}
