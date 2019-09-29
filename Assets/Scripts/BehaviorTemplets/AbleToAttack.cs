using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IAbleToAttack<T>
{
  int attackDamage {get; set;}


  T Attack();   
}
