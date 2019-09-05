using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class UiManager : MonoBehaviour
{
    [SerializeField]
    Button[] towerButtons;
    [SerializeField]
    Tower[] towers;
    [SerializeField]
    TextMeshProUGUI goldAmount;

    void Start()
    {
        FindObjectOfType<BuySellScript>().PayEvent += SetGoldAmount;
        goldAmount.text = Player.gold.ToString();

    }

    void SetGoldAmount(int gold)
    {
       goldAmount.text = gold.ToString();
       LoopThroughTowers();
    }

    void LoopThroughTowers()
    {
        for (int i = 0; i < towerButtons.Length; i++)
        {
           if(towers[i].cost > Player.gold)
           {
                towerButtons[i].interactable = false;
           }
           else if(towers[i].cost <= Player.gold)
           {
                towerButtons[i].interactable = true;
            }
        }
    }
    public void SellButtonLogic()
    {
     GameManager.SetGameState(GameState.Selling);
    }
}
