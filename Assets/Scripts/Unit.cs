using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Unit : MonoBehaviour
{
    public NavMeshAgent agent;
    public GameObject finishPoint;


    void Update()
    {
        if(Input.GetKeyDown(KeyCode.P))
        {  
            agent.SetDestination(finishPoint.transform.position);
        }
    }
}
