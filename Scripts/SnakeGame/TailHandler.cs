using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TailHandler : MonoBehaviour
{
    public List<Vector2> positions;
    public int tailcount;
    public GameObject tailCell,cells;

    int posLenght = 0;

    Vector2 loc;




    private void FixedUpdate()
    {
        if (GameObject.FindGameObjectsWithTag("Cell").Length < tailcount)
        {
            GameObject cell = Instantiate(tailCell);
            cell.transform.SetParent(cells.transform);
            cell.transform.position = new Vector3(loc.x, loc.y, 0);
        }
    }
    public void UpdatePositions(Vector3 position)
    {
        Vector2 pos = new Vector2(position.x,position.y);
        loc = pos;
        TailLenght(pos);


    }
    //private void TailLenght(Vector2 pos)
    //{
    //   if(GameObject.FindGameObjectsWithTag("Cell").Length < tailcount)
    //    {
    //       GameObject cell = Instantiate(tailCell);
    //        cell.transform.position = new Vector3(pos.x,pos.y,0);
    //    }
    //}
    public void TailLenght(Vector2 pos)
    {
        if (posLenght < tailcount)
        {
            Debug.Log("PosLenght: " + posLenght);
            positions.Insert(posLenght, pos);
            posLenght++;
        }
        else posLenght = 0;
        if (positions.Count == tailcount + 1) positions.RemoveAt(tailcount);

    }

}
