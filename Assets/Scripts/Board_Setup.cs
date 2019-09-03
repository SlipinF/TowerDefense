using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Board_Setup : MonoBehaviour
{
    [SerializeField]
    private GameObject tile;
    GameObject Copy;

    private void Start()
    {
        GameObject[,] TileMatrix = new GameObject[10,10]; //change here if you want to change the size of the board!
        InstatiateTiles(TileMatrix);
    }

    void InstatiateTiles(GameObject[,] ArrayOfTiles)
    {
        int CurrentRow = 0;
        int CurrentCol = 0;
                
        foreach (var cor in ArrayOfTiles)
        {
            Copy = Instantiate(tile, new Vector3(CurrentRow, 0, CurrentCol),Quaternion.identity.normalized,gameObject.transform);
            CurrentCol++;

            if (CurrentCol >= ArrayOfTiles.GetLength(0))
            {
                CurrentRow++;
                CurrentCol = 0;
            }
            if (CurrentRow >= ArrayOfTiles.GetLength(1))
            {
                CurrentRow = 0;
            }
        }
    }
}
