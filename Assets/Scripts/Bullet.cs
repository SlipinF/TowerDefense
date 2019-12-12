using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Bullet : MonoBehaviour
{
    GameObject target;
    
    public int damage;
    public bool sendFromMagicTower;
    public void ReciveTarget(GameObject unit)
    {
        target = unit;

    }
    public void ReciveDamageValue(int damageFromTower,string name)
    {
        if(target != null)
        {
            if (name == "MagicTower" && target.tag == "AntiMagic")
            {
                damageFromTower /= 2;
            }
      
      }
        damage = damageFromTower;
        
    }

    private void Update()
    {
        
        if (target != null)
            this.transform.position = Lerp(this.transform.position, target.transform.position, 0.1f);
        else
        {
            Destroy(gameObject);
        }
    }

   
   public static Vector3 Lerp(Vector3 start, Vector3 finish, float percentage)
    {
        //Make sure percentage is in the range [0.0, 1.0]
        percentage = Mathf.Clamp01(percentage);

        //(finish-start) is the Vector3 drawn between 'start' and 'finish'
        Vector3 startToFinish = finish - start;

        //Multiply it by percentage and set its origin to 'start'
        return start + startToFinish * percentage;
    }



   
   void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Unit")
        {
           Destroy(gameObject);
        }
    }

}
