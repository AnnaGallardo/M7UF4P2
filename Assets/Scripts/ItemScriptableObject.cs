using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(fileName= "Item", menuName = "ScriptableObject/Items")]

public class ItemScriptableObject : ScriptableObject
{
    public Sprite image;
    public int price;
}
