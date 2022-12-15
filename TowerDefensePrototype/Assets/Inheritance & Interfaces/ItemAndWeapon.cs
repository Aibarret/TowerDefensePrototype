using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Weapon
{
    public abstract void inspect();

}

public abstract class Item
{
    public abstract void Use();

}

public class Sword : Weapon
{
    public override void inspect()
    {
        Debug.Log("IT'S A SWORD, IT HAS A GOOD POINT");
    }
}

public class Potion : Item
{
    public override void Use()
    {
        Debug.Log("It's a potion, it has the potential to help or harm");
    }
}
