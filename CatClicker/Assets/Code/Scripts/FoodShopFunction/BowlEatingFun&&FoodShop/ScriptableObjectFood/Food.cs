using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[CreateAssetMenu(fileName ="New Food",menuName ="Food/Create new Item")]
public class Food : ScriptableObject 
{
    public Sprite ImageFood;
    public int ValueToIncrease;
    public string NameFood;
}
