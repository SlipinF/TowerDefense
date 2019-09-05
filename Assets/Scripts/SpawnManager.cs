using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class SpawnManager : MonoBehaviour
{
    public event Action OnSpawnEvent;

    [SerializeField]
    GameObject[] unitsToSpawn;

    public List<GameObject> spawnedUnits;
    int waveNr;
    public GameObject startPoint;
    GameObject copy;


    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.P))
        {
            SpawnWave();
            OnSpawnEvent?.Invoke();
        }
    }

    void SpawnWave()
    {
        foreach (var unit in unitsToSpawn)
        {         
            copy = Instantiate(unit, startPoint.transform.position, Quaternion.identity);
            spawnedUnits.Add(copy);
        }
    }

    public void RemoveDeadUnitFromList(GameObject unit)
    {
       spawnedUnits.Remove(unit);
    }


}
