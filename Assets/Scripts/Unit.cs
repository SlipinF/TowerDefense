using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using System;

public class Unit : MonoBehaviour
{
    public event Action OnDeathEvent;

    public NavMeshAgent agent;
    public GameObject finishPoint;

    public UnitObject unitDescirption;
    UnitObject clone;

    private void Awake()
    {
        finishPoint = GameObject.FindGameObjectWithTag("Finish");
    }

    private void Start()
    {
     clone = Instantiate(unitDescirption);
     agent.SetDestination(finishPoint.transform.position);
    }

    public void DamageUnit(int damage)
    {
        clone.health -= damage;
        if (clone.health <= 0)
        {
            OnDeathEvent?.Invoke();
            FindObjectOfType<SpawnManager>().RemoveDeadUnitFromList(gameObject);
            FindObjectOfType<GameManager>().OnKillMethod(gameObject);
            Destroy(gameObject);
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Bullet")
        {
            DamageUnit(other.GetComponent<Bullet>().damage);
        }
    }

}
