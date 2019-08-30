using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tile : MonoBehaviour
{
    bool isTileTaken;

    private void OnMouseOver()
    {

        if(isTileTaken)
        gameObject.GetComponent<Renderer>().material.color = Color.red;
        else{
        gameObject.GetComponent<Renderer>().material.color = Color.green;
        }
        if(Input.GetKeyDown(KeyCode.Mouse0) && isTileTaken == false)
        {
            FindObjectOfType<GameManager>().OnBuildMethod(this.gameObject);
            isTileTaken = true;
        }
    }
    private void OnMouseExit()
    {
        gameObject.GetComponent<Renderer>().material.color = Color.white;
    }
}
