using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

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
        cellstore[0].GetComponent<SpriteRenderer>().color = Color.yellow;
        for (int i = 0; i < cellstore.Count; i++)
        {
            cellstore[i].transform.position = positions[i];
            
        }
    }

    public void TailLenght(Vector2 pos)
    {
        positions.Insert(0, pos);
        if (positions.Count == cellcount + 1) positions.RemoveAt(cellcount);
       
    }

}
#endregion