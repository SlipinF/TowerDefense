using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(fileName = "New Level", menuName = "Levels")]
public class LevelObject : ScriptableObject
{
    public new string name;
    public GameObject[] enemies;
}
