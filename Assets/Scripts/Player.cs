
using UnityEngine;
using System;

public class Player : MonoBehaviour
{
    public static event Action PlayerDiedEvent;

    
    public static int health = 100;
    public static int gold = 100;
    public static int level = 1;

    public static int ChangeGold(int price, bool sell)
    {
        if(sell){
            gold += price;
        }
        else{
            gold -= price;
        }

        return gold;
    }

    public static int ChangeHealth(int damage)
    {
        health -= damage;

        FindObjectOfType<UiManager>().updateHealth(health);

        if(health <= 0)
        {
            PlayerDiedEvent?.Invoke();
        }
        return health;
    }
}
