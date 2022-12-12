using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Character
{
    public GameObject controller;

    public abstract int speed { get; }

    public abstract void speak();

    public virtual void walk()
    {
        controller.transform.position += new Vector3(speed, 0, 0);
    }

    public abstract void attack();
}

public class Human : Character
{
    public override int speed { get => 2; }

    public override void speak()
    {
        Debug.Log("I am a human");
    }

    public override void attack()
    {
        Debug.Log("The Human swings a sword!");
    }

    
}

public class Orc : Character
{
    public override int speed { get => 1; }
    public override void speak()
    {
        Debug.Log("I am a Orc");
    }

    public override void attack()
    {
        Debug.Log("The Orc swings their hammer!");
    }


}

public class Elf : Character
{
    public override int speed { get => 3; }
    public override void speak()
    {
        Debug.Log("I am a Elf");
    }
    public override void attack()
    {
        Debug.Log("The Elf draws their bow!");
    }


}
