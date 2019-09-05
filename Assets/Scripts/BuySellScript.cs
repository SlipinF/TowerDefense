using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class BuySellScript : MonoBehaviour
{
    private Tower tower;

    public event Action<int> PayEvent;
    private void Start()
    {
        FindObjectOfType<GameManager>().BuildEvent += PayGold;
        FindObjectOfType<GameManager>().SellEvent += ReciveGold;
        FindObjectOfType<GameManager>().KillEvent += ReciveGoldFromKill;
    }


    void PayGold(GameObject Tower, GameObject Tile)
    {
        tower = (Tower)Tower.GetComponent<TowerLogic>().towerType;
        PayEvent?.Invoke(Player.ChangeGold(tower.cost, false));
    }

    void ReciveGold(GameObject Tile)
    {
        tower = (Tower)Tile.transform.GetChild(0).GetComponent<TowerLogic>().towerType;
        PayEvent?.Invoke(Player.ChangeGold(tower.cost, true));
    }
    void ReciveGoldFromKill(int amount)
    {
        PayEvent?.Invoke(Player.ChangeGold(amount, true));
    }
}
