using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tile : MonoBehaviour
{
    bool isTileTaken;

    private void OnMouseOver(){
        if (GameManager.currentState == GameState.Building)
        {
            if (isTileTaken)
            gameObject.GetComponent<Renderer>().material.color = Color.red;
            else
            {
            gameObject.GetComponent<Renderer>().material.color = Color.green;
            }

            if (Input.GetKeyDown(KeyCode.Mouse0) && isTileTaken == false)
            {
                FindObjectOfType<GameManager>().OnBuildMethod(this.gameObject);
                GameManager.SetGameState(GameState.Default);
                isTileTaken = true;
            }
        }

        if(isTileTaken && GameManager.currentState == GameState.Selling)
        {
            if (Input.GetKeyDown(KeyCode.Mouse0))
            {
                FindObjectOfType<GameManager>().OnSellMethod(this.gameObject);
                GameManager.SetGameState(GameState.Default);
                isTileTaken = false;
            }
        }
    }

    private void OnMouseExit()
    {
        gameObject.GetComponent<Renderer>().material.color = Color.white;
    }
}
