using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
public enum GameState{Default,Building,Selling}

public class GameManager : MonoBehaviour{

    public static GameState currentState;
    public static GameObject objectToBuild;
    static GameObject CopyobjectToBuild;
    public Camera gameCamera;

    public event Action<GameObject,GameObject> BuildEvent;
    public event Action<GameObject> SellEvent;
    public event Action<int> KillEvent;

    [SerializeField]
    GameObject tower;

    private void Start(){
        currentState = GameState.Default;

    }


    private void Update(){
        if(CopyobjectToBuild == null){
            return;
        }
        else{
            RaycastHit hit;
            Ray ray = gameCamera.ScreenPointToRay(Input.mousePosition);

            if (Physics.Raycast(ray, out hit))
            {
                CopyobjectToBuild.transform.position = new Vector3(hit.point.x,0, hit.point.z);
            }
        }
    }

        public void SetObjectTo(GameObject tower){
            SetGameState(GameState.Building);
            CopyobjectToBuild = Instantiate(tower, Camera.main.ScreenToWorldPoint(Input.mousePosition), Quaternion.identity);
        }

        public static void SetGameState(GameState state){
            currentState = state;
        }

         public void OnBuildMethod(GameObject Tile){
          BuildEvent?.Invoke(CopyobjectToBuild,Tile);
          CopyobjectToBuild = null;
         } 

        public void OnSellMethod(GameObject Tile){
            SellEvent?.Invoke(Tile);
        }
        
        public void OnKillMethod(GameObject unit)
        {
            int amount = unit.GetComponent<Unit>().unitDescirption.goldRevarde;
        KillEvent?.Invoke(amount);

    }


}
