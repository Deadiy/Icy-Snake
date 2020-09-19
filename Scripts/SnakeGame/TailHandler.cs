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
            
            while (cellcount > tailcount)
            {
                GameObject cell = Instantiate(tailCell);
                cell.transform.SetParent(cells.transform);
                Debug.Log(cell.transform.GetSiblingIndex());
                cell.GetComponent<CellHandler>().ttl = 1;
                cell.transform.position = new Vector3(loc.x, loc.y, 0);
                yield return new WaitForSeconds(spawnTime);
            }

        }

    }
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