using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TailHandler : MonoBehaviour
{
    public List<Vector2> positions;
    public int tailcount;
    public GameObject tailCell, cells;
    public List<GameObject> cellstore;
    public int cellcount;
    public Vector3 player;
    int posLenght = 0;
    private float spawnTime = 0.178f;
    Vector2 loc;

 
    bool limiter = false;

    private void Awake()
    {
        cells.transform.SetParent(null);

        StartCoroutine(SpawnObject());
        InvokeRepeating("UpdatePositions", 0, 0.178f);
    }
    private void Update()
    {
        tailcount = cells.transform.childCount;
        tailCell.GetComponent<CellHandler>().cellcount = cellcount;

    }

    public IEnumerator SpawnObject()
    {
        while (true)
        {
           if (tailcount < cellcount)
            {
                if (limiter == false)
                {
                    limiter = true;
                    GameObject cell = Instantiate(tailCell);
                    cell.transform.SetParent(cells.transform);
                    //Debug.Log(cell.transform.GetSiblingIndex());
                    //cell.transform.position = new Vector3(loc.x, loc.y, 0);
                    cellstore.Add(cell);
                    limiter = false;
                }
            }
            yield return new WaitForSeconds(spawnTime);
        }

    }

 #region TailPos
    public void UpdatePositions()
    {
        Vector2 pos = new Vector2(player.x, player.y);
        TailLenght(pos);
        for (int i = 0; i < cellstore.Count; i++)
        {
            cellstore[i].transform.position = new Vector3(positions[i].x, positions[i].y, 0);
        }

    }

    public void TailLenght(Vector2 pos)
    {
        if (posLenght < cellcount)
        {
            positions.Insert(posLenght, pos);
            posLenght++;
        }
        else posLenght = 0;
        if (positions.Count == cellcount + 1) positions.RemoveAt(cellcount);

    }

}
#endregion