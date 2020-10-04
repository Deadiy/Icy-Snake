using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TailHandler : MonoBehaviour
{
    public List<Vector2> positions;
    public int tailcount;
    public GameObject tailCell, cells;

    public int cellcount;

    int posLenght = 0;
    private float spawnTime = 0.178f;
    Vector2 loc;

    bool limiter = false;

    private void Awake()
    {
        cells.transform.SetParent(null);

        StartCoroutine(SpawnObject());
    }
    private void Update()
    {
        tailcount = cells.transform.childCount;


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
                    cell.GetComponent<CellHandler>().ttl = 0.2f + (cell.transform.GetSiblingIndex() +1 ) ;
                    cell.transform.position = new Vector3(loc.x, loc.y, 0);
                    limiter = false;
                }
            }
            yield return new WaitForSeconds(spawnTime);
        }

    }

 #region TailPos
    public void UpdatePositions(Vector3 position)
    {
        Vector2 pos = new Vector2(position.x, position.y);
        loc = pos;
        TailLenght(pos);
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