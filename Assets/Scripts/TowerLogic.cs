using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class TowerLogic : MonoBehaviour
{       
    public Tower towerType;
    GameObject unitToShootAt;
    public GameObject bullet;
    GameObject copy;

  

    public void BeginLogic()
    {
        FindObjectOfType<SpawnManager>().OnSpawnEvent += ChooseUnitToShoot;
        StartCoroutine(Shoot());
    }
    void Update()
    {
        if(unitToShootAt == null)
        {
         ChooseUnitToShoot();
        }

    }

    IEnumerator Shoot()
    {
        while(true)
        {
            yield return new WaitForSeconds(1);
            copy = Instantiate(bullet, this.transform.position, Quaternion.identity);
            copy.GetComponent<Bullet>().ReciveTarget(unitToShootAt);
            copy.GetComponent<Bullet>().ReciveDamageValue(towerType.attackDamage);
        }
    }

    void ChooseUnitToShoot()
    {
        int counter = 0;

        if(FindObjectOfType<SpawnManager>().spawnedUnits.Count > 0)
        {
            GameObject[] testArray = new GameObject[FindObjectOfType<SpawnManager>().spawnedUnits.Count];

            foreach (var unit in FindObjectOfType<SpawnManager>().spawnedUnits)
            {
                if (Vector3.Distance(this.transform.position, unit.transform.position) <= towerType.range)
                {
                    testArray[counter++] = unit;
                }
            }

            if (unitToShootAt != null)
            {
                unitToShootAt.GetComponent<Unit>().OnDeathEvent += ChooseUnitToShoot;
            }

            unitToShootAt = testArray[UnityEngine.Random.Range(0, testArray.Length)];
        }       
    }

    public bool IsEnemyTrue()
    {
        if(unitToShootAt == null)
        {
            return false;
        }
        else
        {
            return true;
        }
    }
}
