using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
  public Vector2 outbounds_topcorner, outbounds_bottomcorner;
    public GameObject player, powerUps , enemies;
    public GameObject[] powerup,enemy;

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
            if (powerUps.transform.childCount <= 0)
                PlaceOnWorld();
        }
        else if(player.GetComponent<PlayerController>().score >= level_barrier)
        {
            if (powerUps.transform.childCount <= 0)
                PlaceOnWorld(true);
        }
    }

    public void PlaceOnWorld(bool spawn_enemy = false)
    {
        GameObject pup = Instantiate(RandomObject(powerup));
        pup.transform.position = NewPlacement();
        pup.transform.SetParent(powerUps.transform);
        if (spawn_enemy)
        {
            GameObject en = Instantiate(RandomObject(enemy));
            en.transform.position = NewPlacement();
            en.transform.SetParent(enemies.transform);
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
        GameObject obj = inst[Random.Range(0, inst.Length)];
        return obj;
    }

    public Vector2 NewPlacement()
    {
        Vector2 meow = new Vector2(Mathf.FloorToInt(Random.Range(outbounds_topcorner.x, outbounds_bottomcorner.x)),
        Mathf.FloorToInt(Random.Range(outbounds_topcorner.y, outbounds_bottomcorner.y)));

        if (meow != oldpos && tail.GetComponent<TailHandler>().CheckPos(meow)== false && CheckPos(meow,enemy) == false)
        {
            oldpos = meow;
            return meow;
        }
        else return NewPlacement();
    }
}
