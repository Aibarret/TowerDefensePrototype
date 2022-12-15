using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterManager : MonoBehaviour
{
    public GameObject character;
    
    private Character characterInit;

    // Start is called before the first frame update
    void Start()
    {
        characterInit = new Human();

        characterInit.controller = character;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            characterInit.walk(new Vector3(0, 1, 0));
        }
        else if (Input.GetKeyDown(KeyCode.DownArrow))
        {
            characterInit.walk(new Vector3(0, -1, 0));
        }
        else if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            characterInit.walk(new Vector3(-1, 0, 0));
        }
        else if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            characterInit.walk(new Vector3(1, 0, 0));
        }

        if (Input.GetKeyDown(KeyCode.Z))
        {
            characterInit.attack();
        }

        if (Input.GetKeyDown(KeyCode.X))
        {
            characterInit.speak();
        }
    }
}
