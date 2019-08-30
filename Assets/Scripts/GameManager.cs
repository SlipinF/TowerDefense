using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
public enum GameState{Default,Building}

public class GameManager : MonoBehaviour
{

    public static GameState currentState;
    public static GameObject objectToBuild;
    static GameObject CopyobjectToBuild;
    public Camera gameCamera;

    public event Action<GameObject,GameObject> BuildEvent;

    [SerializeField]
    GameObject tower;

    private void Start()
    {
        currentState = GameState.Default;

    }


    private void Update()
    {
        if(CopyobjectToBuild == null)
        {
            return;
        }
        else
        {
            RaycastHit hit;
            Ray ray = gameCamera.ScreenPointToRay(Input.mousePosition);

            if (Physics.Raycast(ray, out hit))
            {
                CopyobjectToBuild.transform.position = new Vector3(hit.point.x,0, hit.point.z);
            }
        }
    }

        public void SetObjectTo()
        {
            CopyobjectToBuild = Instantiate(tower, Camera.main.ScreenToWorldPoint(Input.mousePosition), Quaternion.identity);
        }

    public void OnBuildMethod(GameObject Tile)
    {
        BuildEvent?.Invoke(CopyobjectToBuild,Tile);
        CopyobjectToBuild = null;
    } 


}
