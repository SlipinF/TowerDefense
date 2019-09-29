using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using System;

public class Unit : MonoBehaviour , IDamagable , IAbleToAttack<int>
{
    public int health {get; set;}
    public int attackDamage {get; set;}
    public int goldRevarde { get; set; }
    public int speed { get; set; }

    public ArmorType armorType { get; set; }

    public Sprite Icon { get; set; }


    public event Action OnDeathEvent;
    public UnitObject unitDescirption;

    NavMeshAgent agent;
    GameObject finishPoint;

    private void Awake()
    {
      agent = this.gameObject.GetComponent<NavMeshAgent>();
      finishPoint = GameObject.FindGameObjectWithTag("Finish");
    }

    private void Start()
    {
        ApplyScriptibleObjectValues();
        agent.speed = speed;
        agent.SetDestination(finishPoint.transform.position);
    }

    public virtual void GetDamaged(int damage)
    {
        health -= (int)CalculateResistance(damage, unitDescirption.armorType);

            if(health <= 0){
            OnDeathEvent?.Invoke();
            FindObjectOfType<SpawnManager>().RemoveDeadUnitFromList(gameObject);
            FindObjectOfType<GameManager>().OnKillMethod(gameObject);
            Destroy(this.gameObject);
        }
    }

    public virtual int Attack()
    {
        return 0;
    }


    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Bullet")
        {
            GetDamaged(other.GetComponent<Bullet>().damage);
        }

        if(other.tag =="Finish")
        {
            Player.ChangeHealth(unitDescirption.attackDamage);
            FindObjectOfType<SpawnManager>().RemoveDeadUnitFromList(gameObject);
            FindObjectOfType<GameManager>().OnUnitReachGoal();
            Destroy(gameObject);
        }
    }

   public virtual float CalculateResistance(int damage,ArmorType armorType){

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
   public virtual void  ApplyScriptibleObjectValues()
   {
        health = unitDescirption.health;
        attackDamage = unitDescirption.attackDamage;
        goldRevarde = unitDescirption.goldRevarde;
        speed = unitDescirption.speed;

        armorType = unitDescirption.armorType;
        Icon = unitDescirption.icon;
   }
}
