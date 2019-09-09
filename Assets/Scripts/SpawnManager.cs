using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class SpawnManager : MonoBehaviour
{
    public event Action OnSpawnEvent;
    public event Action OnLastRoundFinished;

    [SerializeField]
    GameObject[] unitsToSpawn;

    [SerializeField]
    LevelObject[] arrayOfLevels;

    public List<GameObject> spawnedUnits;
    public GameObject startPoint;
    GameObject copy;
    int currentLevel = 1;

    public void OnGameBegon()
    {
        StartCoroutine(SpawnWave());
        OnSpawnEvent?.Invoke();
        FindObjectOfType<GameManager>().OnRoundEndEvent += EnumarateVariables;
    }
    public void InicializeSpawnWave(){
     StartCoroutine(SpawnWave());
    }


    IEnumerator SpawnWave()
    {
        foreach (var unit in arrayOfLevels[currentLevel].enemies)
        {
            yield return new WaitForSecondsRealtime(0.5f);
            copy = Instantiate(unit, startPoint.transform.position, Quaternion.identity);
            spawnedUnits.Add(copy);
        }
    }

    void EnumarateVariables(){
        currentLevel++;
        if(currentLevel > arrayOfLevels.Length){
          OnLastRoundFinished?.Invoke();
        }
    }
    public void RemoveDeadUnitFromList(GameObject unit)
    {
       spawnedUnits.Remove(unit);
    }
}
