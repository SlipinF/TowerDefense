﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class TowerLogic : MonoBehaviour, IDamagable, IAbleToAttack<IEnumerator>
{       
   public int health {get; set;}
   public int attackDamage {get; set;}



    public Tower towerType;
    GameObject unitToShootAt;
    public GameObject bullet;
    GameObject copy;

    [SerializeField]
    GameObject towerHead;

    public virtual void BeginLogic()
    {
        FindObjectOfType<SpawnManager>().OnSpawnEvent += ChooseUnitToShoot;
        StartCoroutine(Attack());
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

   public virtual IEnumerator Attack()
    {
        while(true)
        {
            yield return new WaitForSeconds(1);
            copy = Instantiate(bullet, towerHead.transform.position, Quaternion.identity);
            copy.GetComponent<Bullet>().ReciveTarget(unitToShootAt);
            copy.GetComponent<Bullet>().ReciveDamageValue(towerType.attackDamage,towerType.name);
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

    public virtual void GetDamaged(int damage)
    {
        health -= damage;

        if (health <= 0)
        {
            Destroy(this.gameObject);
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
