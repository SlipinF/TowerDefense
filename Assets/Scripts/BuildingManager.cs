using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildingManager : MonoBehaviour
{
    void Start(){
        FindObjectOfType<GameManager>().BuildEvent += Build;
        FindObjectOfType<GameManager>().SellEvent += DestroyTower;

    }

    void Build(GameObject Tower,GameObject Tile){
        if(Tower != null){
         Tower.transform.position = Tile.transform.position;
         Tower.transform.SetParent(Tile.transform);
        }
    }

    void DestroyTower(GameObject Tile){
        if(Tile != null){
         Destroy(Tile.transform.GetChild(0).gameObject);
        }
    }
}
