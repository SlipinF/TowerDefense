using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DisplayUiElement : MonoBehaviour
{
    [SerializeField]
    GameObject objectToAlgine;

    bool isActivted  = false;

    GameObject personalButton;
    
    private void Start()
    {
        personalButton = Instantiate(objectToAlgine, FindObjectOfType<Canvas>().transform);
    }
    private void Update()
    {
        personalButton.transform.position = Camera.main.WorldToScreenPoint(transform.position + new Vector3(0,2,1));
    }

    private void OnMouseDown()
    {
        if(isActivted == false)
        {
            personalButton.SetActive(true);
            isActivted = true;
        }
        else
        {
            personalButton.SetActive(false);
            isActivted = false;
        }
    }

}
