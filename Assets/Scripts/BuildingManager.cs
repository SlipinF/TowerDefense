using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildingManager : MonoBehaviour
{
    void Start(){
        FindObjectOfType<GameManager>().BuildEvent += Build;
    }

    void Build(GameObject Tower,GameObject Tile){
        if(Tower != null){
         Tower.transform.position = Tile.transform.position;
        }
    }
}
