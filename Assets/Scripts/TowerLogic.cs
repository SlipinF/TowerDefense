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

    [SerializeField]
    GameObject towerHead;


    [SerializeField]
    public float damping;



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
        else
        {
            RotatTowardsUnit(towerHead,unitToShootAt);
        }

    }



    IEnumerator Shoot()
    {
        while(true)
        {
            yield return new WaitForSeconds(1);
            copy = Instantiate(bullet, towerHead.transform.position + new Vector3(0,1,0), Quaternion.identity);
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

    void RotatTowardsUnit(GameObject towerHead,GameObject target)
    {
        towerHead.transform.LookAt(target.transform.position);
        Vector3 eulerAngles = towerHead.transform.rotation.eulerAngles;
        eulerAngles = new Vector3(0, eulerAngles.y + 90, 0);
        towerHead.transform.rotation = Quaternion.Euler(eulerAngles);
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
