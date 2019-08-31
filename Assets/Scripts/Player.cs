using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    int health = 100;
    int gold = 100;
    int level = 1;

    private Tower tower;

    private void Start(){
     FindObjectOfType<GameManager>().BuildEvent += Pay;
    }


    void Pay(GameObject Tower, GameObject Tile){

        tower = (Tower)Tower.GetComponent<TowerLogic>().towerType;

        gold -= tower.cost;

        Debug.Log("Money Left : " + gold);
    }
}
