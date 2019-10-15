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
    public event Action OnRoundEndEvent;

    bool allUnitsSpawned = false;

    [SerializeField]
    GameObject tower;

    private void Start(){
    currentState = GameState.Default;
    StartCoroutine(BeginGame());
    StartCoroutine(StartCounter());
    FindObjectOfType<SpawnManager>().OnLastUnitSpawned += SetUnitBool;
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
                CopyobjectToBuild.transform.position = new Vector3(hit.point.x,1, hit.point.z);
            }
        }



    }

        IEnumerator BeginGame()
        {
        yield return new WaitForSeconds(21);
        FindObjectOfType<SpawnManager>().OnGameBegon();
        }

        IEnumerator ContinueGame()
        {
        yield return new WaitForSeconds(21);
        FindObjectOfType<SpawnManager>().InicializeSpawnWave();
        }


    IEnumerator StartCounter()
        {
        for (int i = 0; i < 21; i++)
        {
            yield return new WaitForSeconds(1);
            FindObjectOfType<UiManager>().TimerCountDown();
        }
        }

        bool EndRound(){
           if(FindObjectOfType<SpawnManager>().spawnedUnits.Count < 1)
           {
            return true;
           }
           else{
           return false;
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
          CopyobjectToBuild.GetComponent<TowerLogic>().BeginLogic();
          CopyobjectToBuild = null;
         } 

        public void OnSellMethod(GameObject Tile){
            SellEvent?.Invoke(Tile);
        }
        
        public void OnKillMethod(GameObject unit)
        {
        int amount = unit.GetComponent<Unit>().unitDescirption.goldRevarde;
        KillEvent?.Invoke(amount);

        if(EndRound() && allUnitsSpawned)
        {
          StopAllCoroutines();
          OnRoundEndEvent?.Invoke();
          FindObjectOfType<UiManager>().counter = 20;
          StartCoroutine(StartCounter());
          StartCoroutine(ContinueGame());
          allUnitsSpawned = false;
        }
        }


        public void OnUnitReachGoal()
        {
            if(EndRound() && allUnitsSpawned)
            {
            StopAllCoroutines();
            OnRoundEndEvent?.Invoke();
            FindObjectOfType<UiManager>().counter = 20;
            StartCoroutine(StartCounter());
            StartCoroutine(ContinueGame());
            allUnitsSpawned = false;
            }
        }
        
    void SetUnitBool(){
        allUnitsSpawned = true;
    }

    void MobEnteredTrigger()
    {

    }

}
