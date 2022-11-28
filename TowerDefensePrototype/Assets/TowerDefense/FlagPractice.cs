using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlagPractice : MonoBehaviour
{
    
    public enum Type
    {
        fire = 1, //0001
        water = 2, //0010
        grass = 4, //0100
        fireWater = 3 // 0011
    }

    Type type = Type.fireWater;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Z))
        {
            dealDamage(Type.fire);
        }

        if (Input.GetKeyDown(KeyCode.X))
        {
            dealDamage(Type.water);
        }

        if (Input.GetKeyDown(KeyCode.C))
        {
            dealDamage(Type.grass);
        }
    }

    public void dealDamage(Type damagetype)
    {
        if (type.HasFlag(damagetype))
        {
            print("IT'S NOT VERY EFFECTIVE");
        }
        else
        {
            print("IT DID NORMAL DAMGE");
        }

    }
}
