using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tile : MonoBehaviour
{
    private void OnMouseOver()
    {
        gameObject.GetComponent<Renderer>().material.color = Color.green;
    }
    private void OnMouseExit()
    {
        gameObject.GetComponent<Renderer>().material.color = Color.white;
    }
}
