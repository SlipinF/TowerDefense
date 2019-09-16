using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public enum ArmorType {Light,Medium,Heavy}


[CreateAssetMenu(fileName = "New Unit", menuName = "Units")]
public class UnitObject : ScriptableObject
{
    public new string name;
    public string description;

    public Sprite icon;

    public int attackDamage;
    public int health;
    public int goldRevarde;
    public int speed;

    public ArmorType armorType;
}
