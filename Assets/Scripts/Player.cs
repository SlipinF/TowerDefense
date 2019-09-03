
using UnityEngine;

public class Player : MonoBehaviour
{
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
}
