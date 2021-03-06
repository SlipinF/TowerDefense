﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(fileName = "New Tower", menuName = "Towers")]
public class Tower : ScriptableObject
{
    public new string name;
    public string description;

    public Sprite icon;

    public int attackDamage;
    public int health;
    public int cost;
    public int range;
}
