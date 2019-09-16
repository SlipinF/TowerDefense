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
        agent.speed = unitDescirption.speed;

    }

    private void Start()
    {
     clone = Instantiate(unitDescirption);
     agent.SetDestination(finishPoint.transform.position);
    }

    public void DamageUnit(int damage)
    {
        clone.health -= (int)CalculateResistance(damage, unitDescirption.armorType);

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

    float CalculateResistance(int damage,ArmorType armorType){

        float finalValue = 0;
        switch (armorType)
        {
            case ArmorType.Light:
                finalValue = damage * 1f;
                return finalValue;
            case ArmorType.Medium:
                finalValue = damage * 0.85f;
                return finalValue;
            case ArmorType.Heavy:
                finalValue = damage * 0.5f;
                return finalValue;
            default:
                break;
        }
        return finalValue;
    }

}
