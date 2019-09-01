using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Player : MonoBehaviour
{
    public event Action<int> PayEvent;


    public  static int health = 100;
    public static int gold = 100;
    public static int level = 1;

    private Tower tower;

    private void Start(){
     FindObjectOfType<GameManager>().BuildEvent += Pay;
    }


    void Pay(GameObject Tower, GameObject Tile){       
            tower = (Tower)Tower.GetComponent<TowerLogic>().towerType;

            gold -= tower.cost;
            PayEvent?.Invoke(gold);
    }
}
